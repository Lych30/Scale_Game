using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int _speed;
    private Rigidbody2D _rb;
    [SerializeField] private bool _isHolding = false;
    [SerializeField] private float _direction = 0;
    public bool _canMove = true;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _sr;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void ReadMove(InputAction.CallbackContext context)
    {
        _isHolding = context.control.IsPressed();
        _direction = context.ReadValue<float>();
    }

    private void Move()
    {

        if (!_isHolding)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _animator.Play("Player_Idle");
            return;
        }

        if (!_canMove)
        {
            _animator.Play("Player_Idle");
            return;
        }

        Vector3 vel = new Vector3(_direction * _speed, _rb.velocity.y, 0);
        _rb.velocity = vel;

        if (_sr)
            _sr.flipX = (vel.x <= 0.0f ? true : false);

        if (_animator)
            _animator.Play("Player_Walk");

    }



}
