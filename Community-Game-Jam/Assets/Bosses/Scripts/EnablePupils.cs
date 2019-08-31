using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePupils : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public BoldFacedLie controller;
    public Animator animator;
    public GameObject block;

    StoryAudioManager audio;
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("StoryAudioManager").GetComponent<StoryAudioManager>();
    }
    public void enablePupils() 
    {
        right.SetActive(true);
        left.SetActive(true);
    }

    public void disablePupils() 
    {
        right.SetActive(false);
        left.SetActive(false);
    }

    public void recallProjectiles() 
    {
        controller.recallProjectiles();
    }

    public void death() 
    {
        controller.shootAllProjectiles();
        block.SetActive(false); 
        audio.playAudio(7);
    }

    public void beginStageOne() 
    {
        controller.beginStage1();
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.tag == "Player" && !triggered) 
        {
            triggered = true;
            audio.playAudio(3);
            animator.enabled = true; 
            block.SetActive(true); 
        }
        
    }
}
