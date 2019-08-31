using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Vector2 goal;
    public float speed;
    public float offset;
    Vector2 originalPosition;
    Transform player;
    public int distanceFromPlayer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        goal.x = Random.Range(originalPosition.x - offset, originalPosition.x + offset);
        goal.y = Random.Range(originalPosition.y - offset, originalPosition.y + offset); 
        if (GameObject.FindGameObjectWithTag("Player") != null) 
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) 
        {
            if (Vector2.Distance(transform.position, goal) > 0.2f) 
            {
                transform.position = Vector2.MoveTowards(transform.position, goal, speed * Time.deltaTime);
            }
            else 
            {
                goal.x = Random.Range(originalPosition.x - offset, originalPosition.x + offset);
                goal.y = Random.Range(originalPosition.y - offset, originalPosition.y + offset); 
            }   
        } else if (Vector2.Distance(transform.position, player.transform.position) < distanceFromPlayer) 
        {
            anim.enabled = true;
            if (Vector2.Distance(transform.position, goal) > 0.2f) 
            {
                transform.position = Vector2.MoveTowards(transform.position, goal, speed * Time.deltaTime);
            }
            else 
            {
                goal.x = Random.Range(originalPosition.x - offset, originalPosition.x + offset);
                goal.y = Random.Range(originalPosition.y - offset, originalPosition.y + offset); 
            }   
        } else 
        {
            anim.enabled = false;
        }



    }
}
