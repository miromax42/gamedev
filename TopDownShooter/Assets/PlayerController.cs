using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Button fireButtom;
    public DynamicJoystick joystick;

    public float speed;
    public Rigidbody2D rb;

    private float lastActualRotation=0;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //movement
        Vector3 direction = Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal;
        rb.velocity=direction * speed * Time.fixedDeltaTime;
        //rotation
        if (direction.magnitude > 0.05)
        {
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            lastActualRotation = angle;
        }
        else
        {
            rb.rotation = lastActualRotation;
        }
    
   
    }

}   
