using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log("interact from : " + this.gameObject.name);
    }
}
