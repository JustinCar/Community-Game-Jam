using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryAudioManager : MonoBehaviour
{
    AudioSource audio; // Reference to the AudioSource component.
    public GameObject endGameTxt;
    public AudioClip story1;
    public AudioClip story2;
    public AudioClip story3;
    public AudioClip story4;
    public AudioClip story5;
    public AudioClip story6;
    public AudioClip story7;
    public AudioClip storyExtra1;
    public AudioClip storyExtra2;
    public AudioClip storyExtra3;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent <AudioSource> ();
    }

    public void playAudio(int number) 
    {
        if (number == 7) 
        {
            StartCoroutine(endGame());
        }

        switch (number) 
        {
            case 1:
            audio.PlayOneShot(story1);
            break;
            case 2:
            audio.PlayOneShot(story2);
            break;
            case 3:
            audio.PlayOneShot(story3);
            break;
            case 4:
            audio.PlayOneShot(story4);
            break;
            case 5:
            audio.PlayOneShot(story5);
            break;
            case 6:
            audio.PlayOneShot(story6);
            break;
            case 7:
            audio.PlayOneShot(story7);
            break;
            case 8:
            audio.PlayOneShot(storyExtra1);
            break;
            case 9:
            audio.PlayOneShot(storyExtra2);
            break;
            case 10:
            audio.PlayOneShot(storyExtra3);
            break;
        }
        
    }

    IEnumerator endGame() 
    {
        yield return new WaitForSeconds(10);
        endGameTxt.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
    }
}
