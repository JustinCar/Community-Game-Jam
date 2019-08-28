using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePupils : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public BoldFacedLie controller;
    public Animator animator;
    public void enablePupils() 
    {
        right.SetActive(true);
        left.SetActive(true);
    }

    public void recallProjectiles() 
    {
        controller.recallProjectiles();
    }

    public void beginStageOne() 
    {
        controller.beginStage1();
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            animator.enabled = true;  
        }
        
    }
}
