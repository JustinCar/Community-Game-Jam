using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage (int amount) 
    {
        currentHealth -= amount;
        if (currentHealth <= 0) 
        {
            die();
        }
    }

    private void die() 
    {
        Destroy(gameObject);
    }
}
