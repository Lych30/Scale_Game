using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ADVERSARIES STATS")]
    [SerializeField] List<AdversaryStats> _EasyAdversaryStats;
    [SerializeField] List<AdversaryStats> _MediumAdversaryStats;
    [SerializeField] List<AdversaryStats> _HardAdversaryStats;
    [SerializeField] List<AdversaryStats> _RagnarokAdversaryStats;

    [Space(20)]
    [Header("LITRES TO DRINK")]
    [SerializeField] int _LitresToDring_Tier1;
    [SerializeField] int _LitresToDring_Tier2;
    [SerializeField] int _LitresToDring_Tier3;
    [SerializeField] int _LitresToDring_Tier4;
    int _LitresToDring = 0;

    [Space(20)]
    [Header("STAGE AND ADVERSARY")]
    [SerializeField] GameObject _stage;
    [SerializeField] GameObject _adversaryPrefab;

    [Space(20)]
    [Header("ANIMATION REFERENCES")]
    [SerializeField] Transform _CountDownContainer;
    [SerializeField] Animator _Billboard;

    [Space(20)]
    [Header("GAME DATA")]
    [SerializeField] float _QTETime = 1f;
    [SerializeField] float PrecisionAmount_Tier1;
    [SerializeField] float PrecisionAmount_Tier2;
    [SerializeField] float PrecisionAmount_Tier3;
    [SerializeField] float PrecisionAmount_Tier4;
    float _precisionAmount = 0;
    public float precisionAmount { get { return _precisionAmount; } }

    [Space(20)]
    [Header("QTES REFERENCES")]
    [SerializeField] QTE _playerQTE;
    public QTE playerQTE { get { return _playerQTE; } }

    [SerializeField] QTE _adversaryQTE;
    public QTE adversaryQTE { get { return _adversaryQTE; } }
    public float qteTime { get { return _QTETime; } }
    private bool _GameActive = false;
    public bool gameActive { get { return _GameActive; } }

    [Space(20)]
    [Header("DEBUG")]
    [SerializeField] Difficulty difficulty;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //FOR DEBUG PURPOSES
        //WILL REMOVE THAT LATER
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetUpGame(difficulty);
        }
    }
    public void SetUpGame(Difficulty difficulty)
    {
        AdversaryStats adversaryStats = GetCorrectStats(difficulty);
        GameObject adversary = Instantiate(_adversaryPrefab,StageReference.instance.adversaryBarrel.position,Quaternion.identity);
        adversary.GetComponent<AdversaryManager>().InitAdversary(adversaryStats);

        PlayerManager.instance.transform.position = StageReference.instance.playerBarrel.position;
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;

        StartCoroutine(StartGame());
    }

    public AdversaryStats GetCorrectStats(Difficulty difficulty)
    {
        int index = 0;
        switch (difficulty)
        {
            case Difficulty.Easy:
                index = Random.Range(0, _EasyAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier1;
                _precisionAmount = PrecisionAmount_Tier1;
                return _EasyAdversaryStats[index];

            case Difficulty.Medium:
                index = Random.Range(0, _MediumAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier2;
                _precisionAmount = PrecisionAmount_Tier2;
                return _MediumAdversaryStats[index];

            case Difficulty.Hard:
                index = Random.Range(0, _HardAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier3;
                _precisionAmount = PrecisionAmount_Tier3;
                return _HardAdversaryStats[index];

            case Difficulty.Ragnarok:
                index = Random.Range(0, _RagnarokAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier4;
                _precisionAmount = PrecisionAmount_Tier4;
                return _RagnarokAdversaryStats[index];

            default:
                index = Random.Range(0, _EasyAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier1;
                _precisionAmount = PrecisionAmount_Tier1;
                return _EasyAdversaryStats[index];
        }
    }

    IEnumerator StartGame()
    {
        _Billboard.Play("Billboard_Enter");
        yield return new WaitForSecondsRealtime(0.5f);
        foreach (Transform countDownElement in _CountDownContainer)
        {
            countDownElement.GetComponent<Animator>().Play("Countdown");
            Debug.Log(countDownElement.name);
            yield return new WaitForSecondsRealtime(1);
        }
        yield return new WaitForSecondsRealtime(1);
        _Billboard.Play("Billboard_Exit");
        yield return new WaitForSecondsRealtime(0.5f);

        _playerQTE.gameObject.SetActive(true);
        _playerQTE.Init();
        _adversaryQTE.gameObject.SetActive(true);
        _adversaryQTE.Init();

        //ENABLE MAIN GAME INPUTS THERE
        _GameActive = true;
    }

}
