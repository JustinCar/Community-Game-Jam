using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;

    public GameObject projectile;
    public GameObject firePos;
    public float shootCooldown;
    float shootTime = 0.0f;

    public Animator anim;

    public float shootOffset;

    Vector3 mousePos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Fire projectile towards mouse position
        // Save mouse position
        // Call attack animation which calls shoot method
        if (Input.GetButton("Fire1") && shootTime >= shootCooldown) 
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            anim.SetBool("isAttacking", true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement.x == 0 && movement.y == 0) 
        {
            anim.SetBool("isRunning", false);
        } else 
        {
            anim.SetBool("isRunning", true);
        }
    }

    public void shoot() 
    {
            Vector2 shootDirection = new Vector2(mousePos.x - transform.position.x, 
            mousePos.y - transform.position.y).normalized;

            GameObject newProjectile = Instantiate(projectile, firePos.transform.position + new Vector3(shootDirection.x * shootOffset, shootDirection.y * shootOffset, 0).normalized , transform.rotation);
            newProjectile.GetComponent<Projectile>().direction = shootDirection;

            shootTime = 0.0f;
            mousePos = Vector3.zero;
    }

    public void finishAttack() 
    {
        anim.SetBool("isAttacking", false);
    }
}
