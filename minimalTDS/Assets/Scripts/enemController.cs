using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb_enemy;

    public float health;
    public  float speed ;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb_enemy = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.2f * speed, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb_enemy.velocity = direction * speed * Time.fixedDeltaTime;
    }
    void OnCollisionEnter2D(Collision2D otherCollider2D)
    {
        if (otherCollider2D.gameObject.tag == "Bullet")
        {

            bulletHit(otherCollider2D);
        }
    }
    void bulletHit(Collision2D otherCollider2D)
    {
        float newHealth = health - otherCollider2D.gameObject.GetComponent<bullet>().damage;
        if (newHealth > 0)
        {
            health = newHealth;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
