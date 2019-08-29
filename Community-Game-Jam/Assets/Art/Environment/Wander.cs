using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Vector2 goal;
    public float speed;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        goal.x = Random.Range(transform.position.x - offset, transform.position.x + offset);
        goal.y = Random.Range(transform.position.y - offset, transform.position.y + offset); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, goal) > 0.2f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, goal, speed * Time.deltaTime);
        }
        else 
        {
            goal.x = Random.Range(transform.position.x - offset, transform.position.x + offset);
            goal.y = Random.Range(transform.position.y - offset, transform.position.y + offset); 
        }
    }
}
