using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speedOffset = 0;
    public bool isDestructible;
    private SoundManager soundManager;
    private GameManager gameManager;

    void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        transform.Translate(Vector2.left * (gameManager.baseSpeed + speedOffset) * Time.deltaTime);

        if (transform.position.x < -24)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Disappears when hits the player
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().health -= damage;
            soundManager.PlayPlayerHit();
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile") && isDestructible) {
            soundManager.PlayBasicEnemyDestroy();
            Destroy(gameObject);
        } else if (other.CompareTag("Projectile") && !isDestructible) {
            soundManager.PlayIndestructableHit();
        }
    }
}
