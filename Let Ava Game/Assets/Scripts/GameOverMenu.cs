using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private Player player;
    private GameState gameState;
    public GameObject gameOverMenuUI;
    public Text distanceText;
    public Text coinText;
    public Text timeText;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        
        coinText.text = ((int)gameState.coinScore).ToString();
        distanceText.text = string.Format("{0}ft", ((int)gameState.distance).ToString());

        string minutes = Mathf.Floor(gameState.time / 60).ToString("00");
        string seconds = (gameState.time % 60).ToString("00");
        timeText.text = string.Format("{0}:{1}", minutes, seconds);
    }

    // Update is called once per frame
    void Update() {
        coinText.text = ((int)gameState.coinScore).ToString();
        distanceText.text = string.Format("{0}ft", ((int)gameState.distance).ToString());

        string minutes = Mathf.Floor(gameState.time / 60).ToString("00");
        string seconds = (gameState.time % 60).ToString("00");
        timeText.text = string.Format("{0}:{1}", minutes, seconds);
        
        if (player.health <= 0) {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0;
            player.health = 5;
        }
    }
}
