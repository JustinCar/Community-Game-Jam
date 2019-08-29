using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenuAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        anim.SetTrigger("Activate");
        Debug.Log("ENTERED");
    }
}
