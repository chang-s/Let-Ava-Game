using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;
    public Text healthText;
    public Text coinText;

    void Start() {
        healthText.text = player.health.ToString();
        coinText.text = ((int)gameManager.score).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.health.ToString();
        coinText.text = ((int)gameManager.score).ToString();
    }
}
