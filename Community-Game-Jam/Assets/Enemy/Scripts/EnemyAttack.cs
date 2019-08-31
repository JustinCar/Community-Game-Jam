using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Animator anim;
    public int damage;
    public ParticleSystem explode;

    
    public GameObject projectile;
    public GameObject firePos;

    public float shootOffset;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void meleeAttack() 
    {
        if (gameObject.layer == 10) 
        {
            audio.playAudio(6);
        } else 
        {
            audio.playAudio(4);  
        }
        
        playerHealth.takeDamage(damage);
    }

    public void kamikazeAttack() 
    {
        audio.playAudio(6);
        playerHealth.takeDamage(damage);
        Instantiate(explode, transform.position, explode.transform.rotation);
        Destroy(gameObject);
    }

    public void shoot() 
    {
        Vector2 shootDirection = new Vector2(playerHealth.gameObject.transform.position.x - transform.position.x, 
        playerHealth.gameObject.transform.position.y - transform.position.y).normalized;

        GameObject newProjectile = Instantiate(projectile, firePos.transform.position+ new Vector3(shootDirection.x * shootOffset, shootDirection.y * shootOffset, 0).normalized, transform.rotation);
        newProjectile.GetComponent<EnemyProjectile>().direction = shootDirection;
    }

    public void attackFinished () 
    {
        anim.SetBool("isAttacking", false);
    }
}
