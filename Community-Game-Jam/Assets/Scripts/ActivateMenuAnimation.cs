using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenuAnimation : MonoBehaviour
{
    Animator anim;

    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        audio.playAudio(11);
        anim.SetTrigger("Activate");
        Debug.Log("ENTERED");
    }
}
