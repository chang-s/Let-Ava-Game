using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public SoundManager soundManager;
    public GameState gameState;
    private bool isPaused = false;

    void Start() {
        // Play main music
        soundManager.playMainGameBGM();

        // Start timing if paused
        Time.timeScale = 1.0f;
    }
    
    void Update()
    {
        gameState.distance += 1.5f * Time.deltaTime;
        gameState.time += 1.0f * Time.deltaTime;

        // Handle Pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        // Handle Game Over
        // if (player.health <= 0) {
        //     gameOverMenuUI.SetActive(true);
        //     Time.timeScale = 0;
        //     player.health = 5;
        // }
    }

    public void Resume() {
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        soundManager.resumeBGM();
        isPaused = false;
    }

    void Pause() {
        //pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        soundManager.pauseBGM();
        isPaused = true;
    }
}
