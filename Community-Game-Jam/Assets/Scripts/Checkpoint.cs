using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameObject player;
    public GameObject pressEArt;
    public GameObject fireArt;
    public int minDistance;

    CheckpointManager manager;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        manager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < minDistance) 
        {
            if (manager.checkpoint != new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y)) 
            {
                pressEArt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    playerHealth.currentHealth = playerHealth.startingHealth;
                    playerHealth.healthBar.value = playerHealth.startingHealth;
                    manager.checkpoint = gameObject.transform.position;
                    fireArt.SetActive(true);
                    pressEArt.SetActive(false);
                }
            }
        } else 
        {
            pressEArt.SetActive(false);
        }
    }
}
