using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WhiteLiesStart : MonoBehaviour
{
    public List<WhiteLieSpawner> spawners;
    public GameObject entranceBlock;
    public GameObject exitBlock;
    public Slider barThree;

    // Update is called once per frame
    void Update()
    {
        if (barThree.value <= 0) 
        {
            entranceBlock.SetActive(false);
            exitBlock.SetActive(false);
            barThree.transform.parent.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {            
            barThree.transform.parent.gameObject.SetActive(true);
            foreach (WhiteLieSpawner s in spawners) 
            {
                s.stage = 1;
            } 
            entranceBlock.SetActive(true);
            exitBlock.SetActive(true);

            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
