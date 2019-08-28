using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    public GameObject pressEArt;
    public GameObject fireArt;
    public int minDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < minDistance) 
        {
            if (playerController.checkpoint != gameObject) 
            {
                pressEArt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    playerController.checkpoint = gameObject;
                    fireArt.SetActive(true);
                    pressEArt.SetActive(false);
                }
            }
        }
    }
}
