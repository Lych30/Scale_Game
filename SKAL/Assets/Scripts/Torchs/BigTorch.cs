using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTorch : Torch
{
    public override void FireOn()
    {
        base.FireOn();
        _torchAnimator.Play("Torch_anim");
    }
    public override void FireOff()
    {
        base.FireOff();
        _torchAnimator.Play("Torch_Off");
    }
}
