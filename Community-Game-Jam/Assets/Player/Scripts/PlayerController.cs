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
        if (Input.GetButton("Fire1") && shootTime >= shootCooldown) 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 shootDirection = new Vector2(mousePos.x - transform.position.x, 
            mousePos.y - transform.position.y);

            GameObject newProjectile = Instantiate(projectile, firePos.transform.position, transform.rotation);
            newProjectile.GetComponent<Projectile>().direction = shootDirection;

            shootTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
