using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;
    private SoundManager soundManager;

    public int damage = 1;
    public float speedOffset = 0;
    public bool isDestructible;
    public ParticleSystem pow;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = gameManager.soundManager;
    }

    void Update() {
        transform.Translate(Vector2.left * (gameManager.baseSpeed + speedOffset) * Time.deltaTime);

        if (transform.position.x < gameManager.leftScreenEdge - 5)
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
            pow.Play();
            transform.DetachChildren();
            soundManager.PlayBasicEnemyDestroy();
            Destroy(gameObject);
        } else if (other.CompareTag("Projectile") && !isDestructible) {
            pow.Play();
            soundManager.PlayIndestructableHit();
        }
    }
}
