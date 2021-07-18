using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public MainGame mainGame;

    public void ResumeGame() {
        mainGame.Resume();
    }  

    public void RestartGame() {
        SceneManager.LoadScene("Main");
    }  

    public void ExitGame() {
        Application.Quit();
    }
}
