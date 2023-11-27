
using UnityEngine;
using UnityEngine.InputSystem;

public class AdversaryManager : MonoBehaviour
{

    [SerializeField] AdversaryStats _stats;
    float _timeOfClick = 0;
    [SerializeField] AdversaryBarrel _barrel;
    [SerializeField] bool debug;
    GameObject _graphics;
    private float speedRatio = 1;
    void Update()
    {
        if (!GameManager.instance.gameActive)
            return;

        if(_timeOfClick > 0)
        {
            _timeOfClick -= Time.deltaTime;
        }
        else
        {
            TryQTE();
        }

    }

    public void InitAdversary(AdversaryStats stats, AdversaryBarrel barrel)
    {
        _stats = stats;
        _barrel = barrel;
        ResetQTEInteractionStatus();
    }

    public void ResetQTEInteractionStatus()
    {
        _timeOfClick = ((1 - GameManager.instance.precisionAmount) + Random.Range(-_stats.outsidePrecision,_stats.insidePrecision)) / speedRatio;
    }

    public void TryQTE()
    {

        if (!GameManager.instance.gameActive)
            return;

        if (GameManager.instance.adversaryQTE.Try())
        {
            _barrel.Sip();
        }

        speedRatio = GameManager.instance.adversaryQTE.circleSpeed;

        ResetQTEInteractionStatus();

    }
}
