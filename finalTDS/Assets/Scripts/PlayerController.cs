using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //general
    //GameManager.Instance.PlayerHealth
    //public Joystick fireJs;
    public Joystick moveJs;
    public Joystick fireJs;

    //move
  
    private Rigidbody2D rb;

    //smoth rotation
    private float aim_angle=0;
    
    private float current_angle=0f, opposite_aim_angle, calculatedAngle;
    //

    
    void Start()
    {
        GameManager.Instance.PlayerPosition = transform;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case ("Enemy"):
                GameManager.Instance.PlayerHealth -= 1;
                break;
            case ("Boarder"):
                break;
            default:
                break;
        }
    }
    #region Move
    public void PlayerMove()
    {
        Vector3 direction = Vector3.up * moveJs.Vertical + Vector3.right * moveJs.Horizontal;
        rb.velocity = direction * GameManager.Instance.PlayerMoveSpeed;
        GameManager.Instance.PlayerPosition = transform;
    }
    #endregion
    #region Rotation
    public void PlayerRotate()
    {
        Vector3 directionRotation = Vector3.up * fireJs.Vertical + Vector3.right * fireJs.Horizontal;
        if (directionRotation.magnitude>0.05f)
        {
            GameManager.Instance.PlayerFireIsActive = true;
            aim_angle = Mathf.Atan2(fireJs.Vertical, fireJs.Horizontal) * Mathf.Rad2Deg + 180f;
            rb.rotation = RotateSmoth(aim_angle) + 90f;
        }
        else
        {
            GameManager.Instance.PlayerFireIsActive = false;
            rb.rotation = calculatedAngle + 90f;
        }
        
    }
    /// <summary>
    /// Right and Smoth angle changer
    /// </summary>
    /// <param name="aim_angle"> final angle to aim</param>
    /// <returns>smothle changing angle whithin a GameManager.Instance.PlayerRotationSpeed and GameManager.Instance.PlayerRotationSpeed chosen</returns>
    float RotateSmoth(float aim_angle)
    {


        opposite_aim_angle = (aim_angle + 180f) % 360f;




        if (Mathf.Abs(current_angle - aim_angle) < GameManager.Instance.PlayerRotationSpeed)
        {
            calculatedAngle = aim_angle;
        }
        else
        {
            if (aim_angle < opposite_aim_angle)
            {
                if (current_angle > aim_angle && current_angle < opposite_aim_angle)
                {
                    calculatedAngle = current_angle - GameManager.Instance.PlayerRotationSpeed;
                }
                else
                {
                    calculatedAngle = current_angle + GameManager.Instance.PlayerRotationSpeed;
                }
            }
            else
            {
                if (current_angle > opposite_aim_angle && current_angle < aim_angle)
                {
                    calculatedAngle = current_angle + GameManager.Instance.PlayerRotationSpeed;
                }
                else
                {
                    calculatedAngle = current_angle - GameManager.Instance.PlayerRotationSpeed;
                }
            }
        }
        /*
        if (calculatedAngle < 0)
        {
            calculatedAngle += 360f;
        }
        else if (calculatedAngle>=360)
        {
            calculatedAngle -= 360f;
        }
        current_angle = calculatedAngle;
        return calculatedAngle;
        */
        //a - (int)Math.Floor((double)a / n) * n;
        calculatedAngle = calculatedAngle - (float)Mathf.Floor((calculatedAngle / 360f)) * 360f;
        current_angle = calculatedAngle;
        return calculatedAngle;

    }
    #endregion
}

