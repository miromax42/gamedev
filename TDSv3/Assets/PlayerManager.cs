using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;

    private Vector2 move;
    private Vector2 fire;
    private float angle=0,prev_angle=0,final_angle;

    public float speed;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        //float angle = Mathf.Atan2(fireJs.Vertical, fireJs.Horizontal) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        controls.Gameplay.Fire.performed += ctx => fire = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Fire.canceled += ctx => fire = Vector2.zero;

        rb = GetComponent<Rigidbody2D>();

        
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
        Fire();
        
        
        
        
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Move()
    {
        rb.velocity = move * speed;
    }

    void Fire()
    {
        prev_angle = final_angle;
        angle = Mathf.Atan2(fire.y, fire.x) * Mathf.Rad2Deg - 90f;
        if (Mathf.Abs(prev_angle - angle) < 10)
        {

            final_angle = angle;
        }
        else if (prev_angle < angle)
        {
            final_angle = angle + 10;
        }
        else
        {
            final_angle = angle - 10;
        }
        rb.rotation = final_angle;
    }

   
}
