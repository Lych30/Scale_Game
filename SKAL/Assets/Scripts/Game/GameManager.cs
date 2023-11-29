using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Difficulty _currentDifficulty = Difficulty.Easy;
    [SerializeField] int _winsBeforeDifUp;

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
    public int litreToDrink { get { return _LitresToDring; } }


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



    SpriteRenderer _ennemyRenderer;
    GameObject _adversary;
    AdversaryStats _adversaryStats;
    [SerializeField] GameObject _vaArena;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadAdversary();
    }

    public void LoadAdversary()
    {
        //LOAD NEXT ADVERSARY
        _adversaryStats = GetCorrectStats(_currentDifficulty);
        GameSelectionMenu.instance.Init(_adversaryStats);
    }

    public void SetUpGame()
    {
        
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
        PlayerManager.instance.GetComponent<PlayerInteract>().CanInteract = false;
        PlayerManager.instance._barrel = StageReference.instance.playerBarrel;
        Vector3 adversaryPos = new Vector3(StageReference.instance.adversaryBarrel.transform.position.x, PlayerManager.instance.transform.position.y, PlayerManager.instance.transform.position.z);
        
        


        _adversary = Instantiate(_adversaryPrefab, adversaryPos, Quaternion.identity);

        if (_adversaryStats.gfx)
            Instantiate(_adversaryStats.gfx, adversaryPos, Quaternion.identity, _adversary.transform);

        _adversary.GetComponent<AdversaryManager>().InitAdversary(_adversaryStats, StageReference.instance.adversaryBarrel);
        _ennemyRenderer = _adversary.GetComponentInChildren<SpriteRenderer>();

        if( _ennemyRenderer != null )
            _ennemyRenderer.enabled = false;

        StartCoroutine(StartGame());
    }

    public AdversaryStats GetCorrectStats(Difficulty difficulty)
    {
        int index = 0;
        AdversaryStats stats;
        switch (difficulty)
        {
            case Difficulty.Easy:
                index = UnityEngine.Random.Range(0, _EasyAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier1;
                _precisionAmount = PrecisionAmount_Tier1;
                stats = _EasyAdversaryStats[index];
                _EasyAdversaryStats.RemoveAt(index);
                break;

            case Difficulty.Medium:
                index = UnityEngine.Random.Range(0, _MediumAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier2;
                _precisionAmount = PrecisionAmount_Tier2;
                stats = _MediumAdversaryStats[index];
                _MediumAdversaryStats.RemoveAt(index);
                break;

            case Difficulty.Hard:
                index = UnityEngine.Random.Range(0, _HardAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier3;
                _precisionAmount = PrecisionAmount_Tier3;
                stats = _HardAdversaryStats[index];
                _HardAdversaryStats.RemoveAt(index);
                break;

            case Difficulty.Einherjar:
                index = UnityEngine.Random.Range(0, _RagnarokAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier4;
                _precisionAmount = PrecisionAmount_Tier4;
                stats = _RagnarokAdversaryStats[index];
                _RagnarokAdversaryStats.RemoveAt(index);
                break;

            default:
                index = UnityEngine.Random.Range(0, _EasyAdversaryStats.Count);
                _LitresToDring = _LitresToDring_Tier1;
                _precisionAmount = PrecisionAmount_Tier1;
                stats = _EasyAdversaryStats[index];
                _EasyAdversaryStats.RemoveAt(index);
                break;
        }

        return stats;
    }

    public IEnumerator StartGame()
    {
        _GameActive = true;

        StatsMenu.instance.gameObject.SetActive(false);
        ControlsMenu.instance.gameObject.SetActive(false);

        SoundManager.instance.PlaySFX("Gates_closing");
        _versusPanelAnimator.Play("Versus_Entrance");

        yield return new WaitForSeconds(1.0f);
        SoundManager.instance.PlaySFX("Gates_hit");
        StageReference.instance.adversaryBarrel.Init(_LitresToDring, _adversaryStats, _adversarySlider, _currentDifficulty);
        StageReference.instance.playerBarrel.Init(_LitresToDring, PlayerManager.instance.stats, _playerSlider, _currentDifficulty);
        PlayerManager.instance.transform.position = new Vector3(StageReference.instance.playerBarrel.transform.position.x, PlayerManager.instance.transform.position.y, PlayerManager.instance.transform.position.z);
        
        yield return new WaitForSeconds(1.25f);

        if (_ennemyRenderer != null)
            _ennemyRenderer.enabled = true;

        _versusPanelAnimator.Play("Versus_Exit");

        yield return new WaitForSeconds(0.5f);

        if (_barAnimator)
            _barAnimator.Play("Bar_Entrance");

        _Billboard.Play("Billboard_Enter");

        yield return new WaitForSeconds(0.5f);

        foreach (Transform countDownElement in _CountDownContainer)
        {
            countDownElement.GetComponent<Animator>().Play("Countdown");
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

    public IEnumerator GameEnd(bool victory)
    {
        if (_barAnimator)
            _barAnimator.Play("Bar_Exit");

        SoundManager.instance.PlaySFX("Crowd");
        
        _playerQTE.gameObject.SetActive(false);
        _adversaryQTE.gameObject.SetActive(false);

        StageReference.instance.playerBarrel.ResetTMProTexts();
        StageReference.instance.adversaryBarrel.ResetTMProTexts();

        yield return new WaitForSeconds(0.25f);

        _versusPanelAnimator.Play("Versus_Entrance");
        yield return new WaitForSeconds(2f);


        Destroy(_adversary);
        StageReference.instance.adversaryBarrel.DisableVisual();
        StageReference.instance.playerBarrel.DisableVisual();

        if (victory)
        {
            _winsBeforeDifUp--;

            PlayerCoins.instance.AddCurrency(_adversaryStats.currencyReward);
            PlayerManager.instance.stats.magicPoints += _adversaryStats.magicPointsReward;
            PlayerManager.instance.UpdateStats();

            if (_winsBeforeDifUp <= 0)
            {
                UpDifficulty();
                _winsBeforeDifUp = 3;
            }


            LoadAdversary();
        }
       

        

        _versusPanelAnimator.Play("Versus_Exit");
        yield return new WaitForSeconds(0.5f);

        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
        PlayerManager.instance.GetComponent<PlayerInteract>().CanInteract = true;
        _GameActive = false;

        StatsMenu.instance.gameObject.SetActive(true);
        ControlsMenu.instance.gameObject.SetActive(true);


        
    }

    private void UpDifficulty()
    {

        if(_currentDifficulty < Difficulty.Einherjar)
            _currentDifficulty++;

        //CHECK FOR NIGHT TIME WHEN DIFFICULTY IS IN HIGH
        if (_currentDifficulty >= Difficulty.Hard)
            DayCycleManager.instance.TriggerNight();

        if(_currentDifficulty == Difficulty.Einherjar && !_vaArena.activeInHierarchy)
            _vaArena.SetActive(true);
    }
}


