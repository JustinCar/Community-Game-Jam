using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audio; // Reference to the AudioSource component.

    public AudioClip playerAttack;
    public AudioClip projectileHit;
    public AudioClip playerHurt;
    public AudioClip enemyAttackNormal;
    public AudioClip enemyAttackLow;
    public AudioClip enemyAttackHigh;
    public AudioClip buttonClick;
    public AudioClip enemyAttack;
    public AudioClip bossDeath;
    public AudioClip explode;
    public AudioClip bossLaugh;
    public AudioClip bossLaugh2;
    public AudioClip bossRoar;
    public AudioClip bossRoar2;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent <AudioSource> ();
    }

    public void playAudio(int number) 
    {
        switch (number) 
        {
            case 1:
            audio.PlayOneShot(playerAttack);
            break;
            case 2:
            audio.PlayOneShot(projectileHit);
            break;
            case 3:
            audio.PlayOneShot(playerHurt);
            break;
            case 4:
            audio.PlayOneShot(enemyAttackNormal);
            break;
            case 5:
            audio.PlayOneShot(enemyAttackLow);
            break;
            case 6:
            audio.PlayOneShot(enemyAttackHigh);
            break;
            case 7:
            audio.PlayOneShot(buttonClick);
            break;
            case 8:
            audio.PlayOneShot(enemyAttack);
            break;
            case 9:
            audio.PlayOneShot(bossDeath);
            break;
            case 10:
            audio.PlayOneShot(explode);
            break;
            case 11:
            audio.PlayOneShot(bossLaugh);
            break;
            case 12:
            audio.PlayOneShot(bossLaugh2);
            break;
            case 13:
            audio.PlayOneShot(bossRoar);
            break;
            case 14:
            audio.PlayOneShot(bossRoar2);
            break;

        }
        
    }
}
