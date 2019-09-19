using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour
{
    #region Interface
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
    #endregion

    void OnCollisionEnter2D(Collision2D other)
    {
        

        switch (other.gameObject.tag)
        {
            case ("Boarder"):
                gameObject.SetActive(false);
                break;
            case ("Enemy"):
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}