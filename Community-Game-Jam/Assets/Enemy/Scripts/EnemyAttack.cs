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

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void meleeAttack() 
    {
        playerHealth.takeDamage(damage);
    }

    public void kamikazeAttack() 
    {
        playerHealth.takeDamage(damage);
        Instantiate(explode, transform.position, explode.transform.rotation);
        Destroy(gameObject);
    }

    public void shoot() 
    {
        Vector2 shootDirection = new Vector2(playerHealth.gameObject.transform.position.x - transform.position.x, 
        playerHealth.gameObject.transform.position.y - transform.position.y);

        GameObject newProjectile = Instantiate(projectile, firePos.transform.position, transform.rotation);
        newProjectile.GetComponent<Projectile>().direction = shootDirection;
    }

    public void attackFinished () 
    {
        anim.SetBool("isAttacking", false);
    }
}
