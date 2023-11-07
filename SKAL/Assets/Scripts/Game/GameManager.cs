using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Slider _playerSlider;
    [SerializeField] Slider _adversarySlider;
    [SerializeField] Animator _barAnimator;

    [Space(20)]
    [Header("ANIMATION REFERENCES")]
    [SerializeField] Transform _CountDownContainer;
    [SerializeField] Animator _Billboard;
    [SerializeField] Animator _versusPanelAnimator;

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

        if (gameActive)
            return;

        if (Input.GetKeyDown(KeyCode.G))
        {
            SetUpGame(difficulty);
        }
    }
    public void SetUpGame(Difficulty difficulty)
    {
        
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
        PlayerManager.instance._barrel = StageReference.instance.playerBarrel;
        Vector3 adversaryPos = new Vector3(StageReference.instance.adversaryBarrel.transform.position.x, PlayerManager.instance.transform.position.y, PlayerManager.instance.transform.position.z);
        


        AdversaryStats adversaryStats = GetCorrectStats(difficulty);
        StageReference.instance.adversaryBarrel.Init(_LitresToDring, adversaryStats,_adversarySlider);
        StageReference.instance.playerBarrel.Init(_LitresToDring, PlayerManager.instance.Stats, _playerSlider);


        GameObject adversary = Instantiate(_adversaryPrefab, adversaryPos, Quaternion.identity);
        adversary.GetComponent<AdversaryManager>().InitAdversary(adversaryStats,StageReference.instance.adversaryBarrel);

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

            case Difficulty.Einherjar:
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
        _GameActive = true;

        _versusPanelAnimator.Play("Versus_Entrance");
        yield return new WaitForSeconds(1.0f);

        PlayerManager.instance.transform.position = new Vector3(StageReference.instance.playerBarrel.transform.position.x, PlayerManager.instance.transform.position.y, PlayerManager.instance.transform.position.z);
        
        yield return new WaitForSeconds(1.25f);

        _versusPanelAnimator.Play("Versus_Exit");

        yield return new WaitForSeconds(0.5f);

        if (_barAnimator)
            _barAnimator.Play("Bar_Entrance");

        _Billboard.Play("Billboard_Enter");

        yield return new WaitForSeconds(0.5f);

        foreach (Transform countDownElement in _CountDownContainer)
        {
            countDownElement.GetComponent<Animator>().Play("Countdown");
            Debug.Log(countDownElement.name);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        _Billboard.Play("Billboard_Exit");
        yield return new WaitForSeconds(0.5f);

        _playerQTE.gameObject.SetActive(true);
        _playerQTE.Init();
        _adversaryQTE.gameObject.SetActive(true);
        _adversaryQTE.Init();

        //ENABLE MAIN GAME INPUTS THERE
    }

    public void GameEnd(bool victory)
    {
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
        _GameActive = false;

        _playerQTE.gameObject.SetActive(false);
        _adversaryQTE.gameObject.SetActive(false);

        if (_barAnimator)
            _barAnimator.Play("Bar_Exit");
    }

}
