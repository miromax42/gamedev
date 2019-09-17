using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [Range(0,359.99f)]  public float aim_angle;
    public float step;
    public float delta;

    private float current_angle, opposite_aim_angle,calculatedAngle;

    private Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        rb.rotation = RotateSmoth(aim_angle);
        
    }
    /// <summary>
    /// Right and Smoth angle changer
    /// </summary>
    /// <param name="aim_angle"> final angle to aim</param>
    /// <returns>smothle changing angle whithin a step and delta chosen</returns>
    float RotateSmoth(float aim_angle)
    {
        

        opposite_aim_angle = (aim_angle + 180f) % 360f;

       
       

        if (Mathf.Abs(current_angle - aim_angle) < delta)
        {
            calculatedAngle = aim_angle;
        }
        else
        {
            if (aim_angle < opposite_aim_angle)
            {
                if (current_angle > aim_angle && current_angle < opposite_aim_angle)
                {
                    calculatedAngle = current_angle - step;
                }
                else
                {
                    calculatedAngle = current_angle + step;
                }
            }
            else
            {
                if (current_angle > opposite_aim_angle && current_angle < aim_angle)
                {
                    calculatedAngle = current_angle + step;
                }
                else
                {
                    calculatedAngle = current_angle - step;
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
        return calculatedAngle;
        */
        //a - (int)Math.Floor((double)a / n) * n;
        calculatedAngle = calculatedAngle - (float)Mathf.Floor((calculatedAngle / 360f)) * 360f;
        current_angle = calculatedAngle;
        return calculatedAngle;

    }
}
