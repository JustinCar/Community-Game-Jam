using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoldFacedLie : MonoBehaviour
{
    public int stage = 0;
    GameObject player;
    public Rigidbody2D rb;
    public float speed1;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        recallProjectiles();
    }

    public void recallProjectiles() 
    {
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
            if (health1 <= 0) 
            {
                stage = 2;
            }
        } else if (stage == 2) 
        {
            health2 -= damage;
            if (health2 <= 0) 
            {
                stage = 3;
            }
        } else if (stage == 3) 
        {
            health3 -= damage;
            if (health3 <= 0) 
            {
                dead = true;
            }
        }
    }

}
