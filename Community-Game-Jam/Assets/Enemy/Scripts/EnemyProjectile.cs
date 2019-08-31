using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
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

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            return;
        }

        audio.playAudio(10);

        if (collision.gameObject.tag == "Player") 
        {
            Instantiate(explode, transform.position, explode.transform.rotation);
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Terrain") 
        {
            Instantiate(explode, transform.position, explode.transform.rotation);
            Destroy(gameObject);
        }
    }
}
