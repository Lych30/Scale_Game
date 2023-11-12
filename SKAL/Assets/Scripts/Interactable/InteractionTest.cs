using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public void HideAnnotation()
    {
        throw new System.NotImplementedException();
    }

    public void interact()
    {
        Debug.Log("interact from : " + this.gameObject.name);
    }

    public void ShowAnnotation()
    {
        throw new System.NotImplementedException();
    }
}
