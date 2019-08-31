using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoldFacedLie : MonoBehaviour
{
    public int stage = 0;
    GameObject player;
    public Rigidbody2D rb;
    public float speed1;
    public int startingHealth;
    public int health1;
    public int health2;
    public int health3;
    public bool dead = false;

    public float cooldownTime1;
    public float cooldownTime2;

    float timer1 = 0;
    float timer2 = 0;

    public List<LetterProjectile> projectiles;
    public List<LetterProjectile> projectilesShot;

    public Slider healthBar1;
    public Slider healthBar2;
    public Slider healthBar3;
    public GameObject healthBars;
    public GameObject body;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health1 = startingHealth;
        health2 = startingHealth;
        health3 = startingHealth;
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) 
        {
            if (stage > 0) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed1 * Time.deltaTime);
            }

            if (stage > 1) 
            {
                attack();
            }

        }

    }

    void death () 
    {
        body.GetComponent<Animator>().SetBool("Dead", true);
        healthBars.SetActive(false);
    }

    public void shootAllProjectiles() 
    {
        foreach (LetterProjectile p in projectilesShot) 
        {
            p.shoot(2);
        } 
        foreach (LetterProjectile p in projectiles) 
        {
            p.shoot(2);
        } 
    }

    void attack () 
    {
        timer1 += Time.deltaTime;

        if (timer1 >= cooldownTime1) 
        {
            Debug.Log(projectiles.Count);
            int count = projectiles.Count;
            if (count == 0) 
            {
                foreach (LetterProjectile p in projectilesShot) 
                {
                    if (p.attacking == true) 
                    {
                        return;
                    }
                } 

                foreach (LetterProjectile p in projectilesShot) 
                {
                    p.recall();
                    projectiles.Add(p);

                }           
                projectilesShot.Clear();
                timer1 = -5;
            } else
            {
                LetterProjectile closest = findClosestProjectile();
                projectiles.Remove(closest);
                projectilesShot.Add(closest);
                closest.shoot(stage);
                audio.playAudio(14);
                timer1 = 0;                        
            }

        }
    }

    private LetterProjectile findClosestProjectile() 
    {
        int closest = 0;
        for (int i = 1; i < projectiles.Count; i++) 
        {
            if (Vector2.Distance(projectiles[i].transform.position, player.transform.position) 
            < Vector2.Distance(projectiles[closest].transform.position, player.transform.position)) 
            {
                closest = i;
            }
        } 

        return projectiles[closest];
    }

    public void beginStage1 () 
    {
        stage = 1;
        healthBars.SetActive(true);
        recallProjectiles();
    }

    public void recallProjectiles() 
    {
        audio.playAudio(12);
        foreach (LetterProjectile p in projectiles) 
        {
            p.recall();
        } 
    }

    public void takeDamage(int damage) 
    {
        if (stage == 1) 
        {
            health1 -= damage;
            healthBar1.value = health1;
          
            if (health1 <= 0) 
            {
                audio.playAudio(13);
                stage = 2;
            }
        } else if (stage == 2) 
        {
            health2 -= damage;
            healthBar2.value = health2;

            if (health2 <= 0) 
            {
                audio.playAudio(13);
                stage = 3;
            }
        } else if (stage == 3 && !dead) 
        {
            health3 -= damage;
            healthBar3.value = health3;

            if (health3 <= 0) 
            {
                audio.playAudio(13);
                dead = true;
                death();
            }
        }
    }

}
