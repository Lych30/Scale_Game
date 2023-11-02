
using UnityEngine;
using UnityEngine.InputSystem;

public class AdversaryManager : MonoBehaviour
{

    [SerializeField] AdversaryStats _stats;
    float _timeOfClick = 0;

    [SerializeField] bool debug;
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

    public void InitAdversary(AdversaryStats stats)
    {
        _stats = stats;
        ResetQTEInteractionStatus();
    }

    public void ResetQTEInteractionStatus()
    {
        _timeOfClick = (1 - GameManager.instance.precisionAmount) + Random.Range(0.15f, -_stats.precision);
    }

    public void TryQTE()
    {

        if (!GameManager.instance.gameActive)
            return;

        GameManager.instance.adversaryQTE.Try();
        ResetQTEInteractionStatus();

    }
}
