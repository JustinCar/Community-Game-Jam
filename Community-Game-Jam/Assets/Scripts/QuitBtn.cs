using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (button.activeInHierarchy == false) 
            {
                button.SetActive(true);
            } else if (button.activeInHierarchy == true) 
            {
                button.SetActive(false);
            }
        }
    }
}
