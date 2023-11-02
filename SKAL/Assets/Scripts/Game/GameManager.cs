using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] List<AdversaryStats> _EasyAdversaryStats;
    [SerializeField] List<AdversaryStats> _MediumAdversaryStats;
    [SerializeField] List<AdversaryStats> _HardAdversaryStats;
    [SerializeField] List<AdversaryStats> _RagnarokAdversaryStats;
    [SerializeField] GameObject _stage;
    [SerializeField] GameObject _adversaryPrefab;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetUpGame(Difficulty.Easy);
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
                return _EasyAdversaryStats[index];

            case Difficulty.Medium:
                index = Random.Range(0, _MediumAdversaryStats.Count);
                return _MediumAdversaryStats[index];

            case Difficulty.Hard:
                index = Random.Range(0, _HardAdversaryStats.Count);
                return _HardAdversaryStats[index];

            case Difficulty.Ragnarok:
                index = Random.Range(0, _RagnarokAdversaryStats.Count);
                return _RagnarokAdversaryStats[index];

            default:
                index = Random.Range(0, _EasyAdversaryStats.Count);
                return _EasyAdversaryStats[index];
        }
    }

    IEnumerator StartGame()
    {
        Debug.Log("ARE YOU READY ??");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("3");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("2");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("SKOL !!");
        //ENABLE MAIN GAME INPUTS THERE
    }

}
