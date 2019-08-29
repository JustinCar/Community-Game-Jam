using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void quit() 
    {
        Application.Quit();
    }

    public void continueOn() 
    {
        SceneManager.LoadScene("Level1");
    }

    public void newGame() 
    {
        SceneManager.LoadScene("Level1");
    }
}
