using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //Components
    private Rigidbody2D _rb;
    public Transform feetPos;
    public FloatingJoystick floatingJoystick;

    //Private variables
    private float _moveInput;
    //private bool _isJumping;
    private bool _isGrounded;
    private int _numJump = 0;
    private bool _isJumping;

    //Public
    public float speed;
    public float jumpForce;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float recoilForce;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Walking Left and Right
        //_moveInput = Input.GetAxis("Horizontal");
        _moveInput = floatingJoystick.Horizontal;
        _rb.velocity = new Vector2(_moveInput * speed,_rb.velocity.y);

    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (_isGrounded && !_isJumping) _numJump = 0;
    }
  
    public void Jump()
    {
        if (_numJump == 1)
        {
            DoubleJump();
        }
        
        if (_isGrounded)
        {
            _rb.velocity = Vector2.up  * jumpForce;
            _numJump += 1;
            _isJumping = true;
            Invoke("ResetDoubleJump", 0.5f);
        }
    }

    private void DoubleJump()
    {
        _rb.velocity = Vector2.up * jumpForce;
        _numJump += 1;
        ResetDoubleJump();
    }

    private void ResetDoubleJump()
    {
        _isJumping = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(feetPos.position, checkRadius);
    }

    public void Recoil(Vector2 recoilDirection)
    {
        _rb.velocity = new Vector2(0, 0);
        _rb.AddForce(-recoilDirection * recoilForce, ForceMode2D.Impulse);
    }
}
