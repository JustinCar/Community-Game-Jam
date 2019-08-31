using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 direction;
    AudioManager audio;
    public ParticleSystem explode;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            return;
        }

        audio.playAudio(10);

        if (collision.gameObject.tag == "Enemy") 
        {   
            // Projectile can pass through white lies
            if (collision.gameObject.layer == 10) 
            {
                collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
                return;
            }
            Instantiate(explode, transform.position, explode.transform.rotation);
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Terrain") 
        {
            Instantiate(explode, transform.position, explode.transform.rotation);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "BoldFacedLie") 
        {
            collision.gameObject.GetComponent<BoldFacedLie>().takeDamage(damage);
            Instantiate(explode, transform.position, explode.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.gameObject.tag == "EnemyProjectile") 
        {
            Destroy(gameObject);
            // Play Hit Particle Effects
        }
    }
}
