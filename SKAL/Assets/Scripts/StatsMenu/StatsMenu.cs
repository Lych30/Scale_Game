using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenMenu()
    {
        animator.Play("OpenMenu");
    }
    public void CloseMenu()
    {
        animator.Play("CloseMenu");
    }
}
