using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject fireDirection;
    public GameObject projectile;
    public float projectileSpeed;
    public firePointMovement FirePointMovement;
    private bool _canFire = true;
    private Vector2 _recoil;
    public Movement movement;
    public float fireRatio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) fireProjectile();
        if(Input.GetKeyDown(KeyCode.L)) FirePointMovement.ChangeRotationDirection();
    }

    public void fireProjectile()
    {
        if (_canFire)
        {
            Instantiate(projectile, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0f), Quaternion.identity);
            _recoil = new Vector2(fireDirection.transform.position.x - firePoint.transform.position.x,
                fireDirection.transform.position.y - firePoint.transform.position.y);
            movement.Recoil(_recoil);
            StartCooldown();
        }
    }

    void StartCooldown()
    {
        _canFire = false;
        Invoke("FinishCooldown", fireRatio);
    }

    void FinishCooldown()
    {
        _canFire = true;
    }
}
