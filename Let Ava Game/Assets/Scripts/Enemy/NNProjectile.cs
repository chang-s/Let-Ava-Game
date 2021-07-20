using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNProjectile : MonoBehaviour
{
    private GameManager gameManager;
    private SoundManager soundManager;
    private Player player;
    public int damage = 1;
    public float speedOffset = 2;
    public float rotatingSpeed = 200;
    private bool passedPlayer = false;
    Rigidbody2D rb;
    public ParticleSystem pow;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = gameManager.soundManager;
        player = gameManager.player;
        rb = GetComponent<Rigidbody2D> ();
    }
 
    void FixedUpdate() {
        // Check if it is passed the player
        if (transform.position.x < gameManager.playerPosition) {
            passedPlayer = true;
        }

        // Tracks the player until it passed by the player
        if (!passedPlayer) {
            Vector2 point2Target = (Vector2)transform.position - (Vector2)player.transform.position;
            point2Target.Normalize();

            float cross = Vector3.Cross(point2Target, transform.right).z;

            if (cross < 0) {
                rb.angularVelocity = rotatingSpeed;
            } else if (cross > 0) {
                rb.angularVelocity = -rotatingSpeed;
            } else {
                rb.angularVelocity = 0;
            }
        } else {
            rb.angularVelocity = 0;
        }

        rb.velocity = -transform.right * (gameManager.baseSpeed + speedOffset);

        if (transform.position.x < gameManager.leftScreenEdge - 3) {
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
        if (other.CompareTag("Projectile")) {
            pow.Play();
            transform.DetachChildren();
            soundManager.PlayLightEnemyDestroy();
            Destroy(gameObject);
        }
    }
}
