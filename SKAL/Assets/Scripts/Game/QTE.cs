using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class QTE : MonoBehaviour
{
    [SerializeReference] protected AnimationCurve _closingCircleCurve;
    [SerializeReference] protected Transform _targetCircle;
    [SerializeReference] protected Transform _closingCircle;
    [SerializeReference] protected float _progression;
    [SerializeReference] protected float _scaleToSucceed;

    [Space(20)]
    [Header("DEBUG")]
    [SerializeReference] float ratio = 0;
    [SerializeReference] int totalNbr = 0;
    [SerializeReference] int sucess = 0;


    private void Update()
    {
       

       if(_progression < GameManager.instance.qteTime)
       {
            _progression += Time.deltaTime;
            ApplyScale();
            return;
       }
        
        _progression = 0;

    }

    public virtual bool Try() { return false; }

    public void ApplyScale()
    {
        _closingCircle.localScale = Vector3.one * GetCorrectScale(_progression);
    }


    protected float GetCorrectScale(float progression)
    {
        return _closingCircleCurve.Evaluate(_progression);
    }

    public void Init()
    {
        _scaleToSucceed = GameManager.instance.precisionAmount;
        _progression = 0;
        _targetCircle.localScale = Vector3.one * _scaleToSucceed;
        ApplyScale();
    }
}
