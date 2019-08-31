using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterProjectile : MonoBehaviour
{
    public bool attacking = false;
    bool recalled = false;
    Transform player;
    Vector3 directionToPlayer;
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed1;
    public float moveSpeed2;
    public float recallSpeed;
    public int damage;

    float damageCoolDown = 1;
    float timer = 0;

    int stage;

    public Transform slot;
    AudioManager audio;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim.enabled = false;
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (attacking) 
        {
            if (stage == 2) 
            {
                rb.velocity = new Vector2 (directionToPlayer.x * moveSpeed1, directionToPlayer.y * moveSpeed1);  
            } else if (stage == 3) 
            {
                rb.velocity = new Vector2 (directionToPlayer.x * moveSpeed2, directionToPlayer.y * moveSpeed2);  
            }
            
        }

        if (recalled) 
        {
            if (Vector2.Distance(transform.position, slot.position) > 0.5) 
            {
                Vector2 direction = slot.position - transform.position;
                direction = direction.normalized;
                rb.velocity = new Vector2 (direction.x * recallSpeed, direction.y * recallSpeed);    
            } else 
            {

                transform.position = slot.position;
            }

        }
    }

    public void shoot(int stageVal) 
    {
        stage = stageVal;
        recalled = false;
        attacking = true;
        anim.SetBool("spinfast", true);
        directionToPlayer = new Vector2(player.position.x - transform.position.x, 
            player.position.y - transform.position.y).normalized;
    }

    public void recall() 
    {
        recalled = true;
        attacking = false;
        anim.enabled = true;
        anim.SetBool("spinfast", false);
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            if (timer > damageCoolDown) 
            {
                Debug.Log("PLAYER HIT");
                audio.playAudio(11);
                collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
                timer = 0;
            }
        } else if (collision.tag == "Terrain" && attacking) 
        {
            audio.playAudio(2);
            rb.velocity = Vector2.zero;
            attacking = false;
            anim.enabled = false;
        }
    }
}
