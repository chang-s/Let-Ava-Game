using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    public void ResumeGame() {
        gameManager.Resume();
    }  

    public void RestartGame() {
        SceneManager.LoadScene("Main");
    }  

    public void ExitGame() {
        Application.Quit();
    }
}
