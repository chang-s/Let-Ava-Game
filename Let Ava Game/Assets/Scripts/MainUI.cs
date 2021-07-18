using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Player player;
    public GameState gameState;
    public Text healthText;
    public Text coinText;

    void Start() {
        healthText.text = player.health.ToString();
        coinText.text = ((int)gameState.coinScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.health.ToString();
        coinText.text = ((int)gameState.coinScore).ToString();
    }
}
