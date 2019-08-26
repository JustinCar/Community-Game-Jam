﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    private int currentHealth;
    public ParticleSystem explode;

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
        Instantiate(explode, transform.position, explode.transform.rotation);
        Destroy(gameObject);
    }
}
