using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SoundManager SoundManager;
    
    void Start() {
        // Play main music
        SoundManager.PlayMainMenuBGM();
    }

    public void exitGame() {
        Application.Quit();
    }

    public void startGame() {
        SceneManager.LoadScene("Main");
    }  

    public void tutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
