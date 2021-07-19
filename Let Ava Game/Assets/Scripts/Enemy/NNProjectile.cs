using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNProjectile : MonoBehaviour
{
    public int damage = 1;
    public float speedOffset = 2;
    public float rotatingSpeed = 200;
    private bool passedPlayer = false;
    private Player player;
    private SoundManager soundManager;
    private GameManager gameManager;
    Rigidbody2D rb;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        if (transform.position.x < gameManager.leftScreenEdge + 3) {
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
            soundManager.PlayLightEnemyDestroy();
            Destroy(gameObject);
        }
    }
}
