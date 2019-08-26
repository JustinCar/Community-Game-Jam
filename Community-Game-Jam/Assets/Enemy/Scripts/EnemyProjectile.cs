using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            return;
        }

        // Play hit audio

        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
            Destroy(gameObject);
            // Play Hit Particle Effects
        } else if (collision.gameObject.tag == "Terrain") 
        {
            Destroy(gameObject);
            // Play Hit Particle Effects
        }
    }
}
