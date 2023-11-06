using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [SerializeReference] protected Light2D _light;
    [SerializeReference] protected Animator _torchAnimator;
    public virtual void FireOn()
    {
        _light.enabled = true;
    }
    public virtual void FireOff()
    {
        _light.enabled = false;
    }
}
