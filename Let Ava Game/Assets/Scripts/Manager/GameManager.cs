using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    public Player player;

    // UI values
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    private bool isPaused = false;
    private bool isGameOver = false;

    // Values that change over time
    public float score { get; set; } = 0;
    public float distance { get; private set; } = 0;
    public float time { get; private set; } = 0;

    // General values of screen position
    public float leftScreenEdge { get; private set; } = -18.2f;
    public float rightScreenEdge { get; private set; } = 18.2f;
    public float topScreenEdge { get; private set; } = 17.0f;
    public float bottomScreenEdge { get; private set; } = -2.9f;
    public float groundHeight { get; private set; } = 1.7f;
    public float playerPosition { get; private set; }

    // Base values
    public float baseSpeed { get; private set; } = 10f;
    private int baseCoinRate = 1;

    // Pickup values
    private bool activeTimedCoinMultiplier = false;
    private float timeLeftOnCoinMultiplier = 0f;
    public int currentCoinRate { get; private set; }

    void Start() {
        playerPosition = leftScreenEdge + 4.9f;
        currentCoinRate = baseCoinRate;
        
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

        // Handle Coin Multiplier
        if (timeLeftOnCoinMultiplier > 0f) {
            // Count down timer
            timeLeftOnCoinMultiplier -= 1.0f * Time.deltaTime;
        } else if (activeTimedCoinMultiplier) {
            // Reset coin multipler
            ChangeCoinRate(baseCoinRate);
            activeTimedCoinMultiplier = false;
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

    public void ChangeCoinRate(int newRate, float duration = 0f) {
        currentCoinRate = newRate;

        // If duration was not left at default then start timer
        if (duration > 0f) {
            timeLeftOnCoinMultiplier = duration;
        }
    }
}
