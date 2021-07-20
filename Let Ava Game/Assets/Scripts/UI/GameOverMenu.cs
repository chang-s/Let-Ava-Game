using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameManager gameManager;
    public Text distanceText;
    public Text coinText;
    public Text timeText;

    public void OnEnable() {
        coinText.text = ((int)gameManager.score).ToString();
        distanceText.text = string.Format("{0}ft", ((int)gameManager.distance).ToString());

        string minutes = Mathf.Floor(gameManager.time / 60).ToString("00");
        string seconds = (gameManager.time % 60).ToString("00");
        timeText.text = string.Format("{0}:{1}", minutes, seconds);
    }

    public void NextGame() {
        SceneManager.LoadScene("Main");
    }
}
