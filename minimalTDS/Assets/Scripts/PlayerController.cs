using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Joystick fireJs;
    public Joystick moveJs;
    public Joystick fireJs;

    public float speed;
    private Rigidbody2D rb;

    private float lastActualRotation=0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //movement move Js
        Vector3 direction = Vector3.up * moveJs.Vertical + Vector3.right * moveJs.Horizontal;
        rb.velocity=direction * speed * Time.fixedDeltaTime;
        //rotation
        Vector3 directionRotation = Vector3.up * fireJs.Vertical + Vector3.right * fireJs.Horizontal;
        if (directionRotation.magnitude > 0.05)
        {
            float angle = Mathf.Atan2(fireJs.Vertical, fireJs.Horizontal) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            lastActualRotation = angle;
        }
        else
        {
            rb.rotation = lastActualRotation;
        }
    
   
    }

}   
