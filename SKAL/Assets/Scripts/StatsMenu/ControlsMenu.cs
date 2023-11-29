using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public static ControlsMenu instance;
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
        animator.Play("OpenControlsMenu");
    }
    public void CloseMenu()
    {
        animator.Play("CloseControlsMenu");
    }
}
