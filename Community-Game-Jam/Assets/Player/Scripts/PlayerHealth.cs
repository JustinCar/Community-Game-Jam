using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void takeDamage (int amount) 
    {
        currentHealth -= amount;
        healthBar.value -= amount;
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
