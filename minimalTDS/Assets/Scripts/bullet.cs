using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
