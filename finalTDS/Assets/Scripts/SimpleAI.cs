using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*struct SimpleEnemyParams
{
    public float moveSpeed;
    public float damage;
    public float health;
    public SimpleEnemyParams()
    {
        
    }
}
*/
public class SimpleAI : MonoBehaviour
{
    private Vector3 atacDirection;
    private float moveSpeed, damage, health;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.Instance._enemyMeleeMoveSpeed;
        damage = GameManager.Instance._enemyMeleeDamage;
        health = GameManager.Instance._enemyMeleeHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMove();
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case ("Player"):
                MakeDamage();
                break;
            case ("Bullet"):
                TakeDamage(damage);
                break;
            default:
                break;
        }
    }
    private void EnemyMove()
    {
        atacDirection = (GameManager.Instance.PlayerPosition.position - transform.position).normalized;
        rb.velocity = atacDirection * moveSpeed;


    }
    void TakeDamage(float damage)
    {
        health -= GameManager.Instance._bulletDamage;
        if (health <= 0)
        {
            SelfDestroy();
        }
    }
    void SelfDestroy()
    {
        gameObject.SetActive(false);
    }
    void MakeDamage()
    {
        GameManager.Instance.PlayerHealth -= 10;
    }
}
