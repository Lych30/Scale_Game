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
    [SerializeReference,Range(1,3)] protected float _maxCircleSpeed = 2;
    protected float _circleSpeed = 1;
    [SerializeReference] protected ParticleSystem _magicParticleSystem;

    [Space(20)]
    [Header("DEBUG")]
    [SerializeReference] float ratio = 0;
    [SerializeReference] int totalNbr = 0;
    [SerializeReference] int sucess = 0;

    [HideInInspector] public float circleSpeed {  get { return _circleSpeed; } }

    private void Update()
    {
       

       if(_progression < GameManager.instance.qteTime)
       {
            _progression += (Time.deltaTime * _circleSpeed);
            ApplyScale();
            return;
       }
        
        _progression = 0;

    }

    protected void HandleCircleSpeed()
    {
        _circleSpeed += 0.15f;
        if(_circleSpeed > _maxCircleSpeed)
            _circleSpeed = _maxCircleSpeed;
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
