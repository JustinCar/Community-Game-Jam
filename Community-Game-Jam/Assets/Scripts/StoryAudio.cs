using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAudio : MonoBehaviour
{
    StoryAudioManager audio;

    public int number;
    bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("StoryAudioManager").GetComponent<StoryAudioManager>();
    }

    void OnTriggerEnter2D (Collider2D collision) 
    {
        if (collision.tag == "Player" && !played) 
        {
            audio.playAudio(number);
            played = true;
        }
        
    }
    

}
