using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform point;
    public Transform target;

    public float timeBtwShots;
    public float fireRate = 0.64f;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && timeBtwShots < Time.time)
        {
            Shoot();
            timeBtwShots = Time.time + fireRate;
        }
    }

    void Shoot()
    {

        Instantiate(bullet, point.position, point.rotation);
    }
}
