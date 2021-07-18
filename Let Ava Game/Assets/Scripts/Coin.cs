using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
    //private SFXPlayer _SFXPlayer;
    //private GameState _gameState;

    void Start() {
        //_SFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
        //_gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -24)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Disappears when hits the player
        if (other.CompareTag("Player")) {
            //_SFXPlayer.playCoinCollect();
            //_gameState.coinScore += 1;
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile")) {
            //_SFXPlayer.playCollectDestroy();
            Destroy(gameObject);
        }
    }
}
