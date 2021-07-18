using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    public Player player;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    private bool isPaused = false;
    private bool isGameOver = false;

    public float score { get; set; } = 0;
    public float distance { get; private set; } = 0;
    public float time { get; private set; } = 0;

    public float baseSpeed;

    void Start() {
        // Play main music
        soundManager.PlayMainGameBGM();

        // Start timing if paused
        Time.timeScale = 1.0f;
    }
    
    void Update()
    {
        distance += 1.5f * Time.deltaTime;
        time += 1.0f * Time.deltaTime;

        // Handle Pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        // Handle Game Over
        if (player.health <= 0 && !isGameOver) {
            GameOver();
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        soundManager.ResumeBGM();
        isPaused = false;
    }

    private void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        soundManager.PauseBGM();
        isPaused = true;
    }

    private void GameOver() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        soundManager.PlayGameOverBGM();
        isGameOver = true;
    }
}
