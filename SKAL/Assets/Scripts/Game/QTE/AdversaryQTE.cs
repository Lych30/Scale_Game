using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryQTE : QTE
{

    public override bool Try()
    {
        if (GetCorrectScale(_progression) <= _scaleToSucceed)
        {
            _magicParticleSystem.Play();
            HandleCircleSpeed();
            Init();
            return true;
        }
        else
        {
            _circleSpeed = 1;
            Init();
            return false;
        }
    }
}
