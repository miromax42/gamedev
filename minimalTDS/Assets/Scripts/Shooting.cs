using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Joystick fireJs;
    public float nexttimeToFire;
    public float fireRate;

    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionRotation = Vector3.up * fireJs.Vertical + Vector3.right * fireJs.Horizontal;
        if (directionRotation.magnitude > 0.05 && Time.time>=nexttimeToFire)
        {
            nexttimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
    }
    public void shoot()
    {
        GameObject bullet= Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
