using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    public static StatsMenu instance;
    Animator animator;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

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
