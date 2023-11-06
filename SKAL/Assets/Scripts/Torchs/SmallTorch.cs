using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTorch : Torch
{
    public override void FireOn()
    {
        base.FireOn();
        _torchAnimator.Play("Small_Torch_Idle");
    }
    public override void FireOff()
    {
        base.FireOff();
        _torchAnimator.Play("Small_Torch_Off");
    }
}
