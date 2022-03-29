using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FIre : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed;
    public firePointMovement FirePointMovement;
    private bool _canFire = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) fireProjectile();
        if(Input.GetKeyDown(KeyCode.L)) FirePointMovement.ChangeRotationDirection();
    }

    public void fireProjectile()
    {
        if (_canFire)
        {
            Instantiate(projectile, new Vector3(firePoint.position.x, firePoint.position.y, 0f), Quaternion.identity);
            StartCooldown();
        }
    }

    void StartCooldown()
    {
        _canFire = false;
        Invoke("FinishCooldown", 2f);
    }

    void FinishCooldown()
    {
        _canFire = true;
    }
}
