using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public Slider healthBar;
    CheckpointManager manager;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        manager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void takeDamage (int amount) 
    {
        audio.playAudio(3);
        currentHealth -= amount;
        healthBar.value -= amount;
        if (currentHealth <= 0) 
        {
            die();
        }
    }

    private void die() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
