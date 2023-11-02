using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [SerializeField] AnimationCurve _closingCircleCurve;
    [SerializeField] Transform _targetCircle;
    [SerializeField] Transform _closingCircle;
    float _progression;
    [SerializeField] float _scaleToSucceed;

    private void Update()
    {
       if(_progression < GameManager.instance.qteTime)
       {
            _progression += Time.deltaTime;
            ApplyScale();
            return;
       }
        Fail();
        _progression = 0;
    }

    private void Success()
    {
        Debug.Log("Success");
    }

    private void Fail()
    {
        //Debug.Log("Fail");
    }

    public void ApplyScale()
    {
        _closingCircle.localScale = Vector3.one * GetCorrectScale(_progression);
    }

    public void Try()
    {
        if(GetCorrectScale(_progression) <= _scaleToSucceed)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }
    private float GetCorrectScale(float progression)
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
