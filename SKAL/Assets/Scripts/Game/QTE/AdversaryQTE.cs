using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryQTE : QTE
{

    public override bool Try()
    {
        if (GetCorrectScale(_progression) <= _scaleToSucceed)
        {
            Init();
            return true;
        }
        else
        {
            Init();
            return false;
        }
    }
}
