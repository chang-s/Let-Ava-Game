using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SoundManager soundManager;
    private GameManager gameManager;

    void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        transform.Translate(Vector2.left * gameManager.baseSpeed * Time.deltaTime);

        if (transform.position.x < gameManager.leftScreenEdge - 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Disappears when hits the player
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().health += 1;
            soundManager.PlayHeartCollect();
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile")) {
            soundManager.PlayCollectDestroy();
            Destroy(gameObject);
        }
    }
}
