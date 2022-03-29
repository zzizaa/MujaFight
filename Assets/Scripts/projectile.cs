using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private GameObject _firePoint;
    private GameObject _fireDirection;
    public float projectileSpeed;
    public Vector2 _directionVector;
    private Rigidbody2D _rb;
    public float speedRotation;

    private void Awake()
    {
        Destroy(gameObject, 5f);
        
        _firePoint = GameObject.FindWithTag("FirePoint");
        _fireDirection = GameObject.FindWithTag("FireDirection");
        _directionVector = new Vector2( _fireDirection.transform.position.x - _firePoint.transform.position.x,
            _fireDirection.transform.position.y - _firePoint.transform.position.y);
        _rb = GetComponent<Rigidbody2D>();
         
    }

    private void Update()
    {
        _rb.velocity = _directionVector * projectileSpeed;
        transform.Rotate(transform.forward, speedRotation * Time.deltaTime);
    }

    public void SetClockwiseRotation()
    {
        speedRotation = -500f;
    }

    public void SetCounterclockwiseRotation()
    {
        speedRotation = 500f;
    }
}
