using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private float nexttimeToFire = 0f;

    public Transform firePoint;
 



    // Update is called once per frame
    void FixedUpdate()
    {
        WeaponShoot();
    }

    public void WeaponShoot()
    {
        if (GameManager.Instance.PlayerFireIsActive  && Time.time >= nexttimeToFire)
        {
            nexttimeToFire = Time.time + 1f / GameManager.Instance.WeaponFireRate;
            BulletCreate();


        }
    }

    public void BulletCreate()
    {
        GameObject Bullet = PoolManager.GetObject("SimpleBullet", firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * GameManager.Instance.BulletForce, ForceMode2D.Impulse);

    }
}
