using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int _speed;
    private Rigidbody2D m_rb;
    [SerializeField] private bool m_isHolding = false;
    [SerializeField] private float m_direction = 0;
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        m_isHolding = context.control.IsPressed();
        m_direction = context.ReadValue<float>();
    }

    private void Move()
    {
        if (!m_isHolding)
        {
            m_rb.velocity = new Vector3(0, m_rb.velocity.y, 0);
            return;
        }

        Vector3 vel = new Vector3(m_direction * _speed, m_rb.velocity.y, 0);
        m_rb.velocity = vel;
    }



}
