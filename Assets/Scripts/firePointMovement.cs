using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePointMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public float rotationSpeed;
    public Transform fireDirection;
    public projectile Projectile;
    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(playerTransform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        if(transform.position.x > playerTransform.position.x) Projectile.SetClockwiseRotation();
        if(transform.position.x < playerTransform.position.x) Projectile.SetCounterclockwiseRotation();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, fireDirection.position);
    }

    public void ChangeRotationDirection()
    {
        rotationSpeed = -rotationSpeed;
    }
}
