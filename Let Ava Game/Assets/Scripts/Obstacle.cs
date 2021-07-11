using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public bool isDestructible;
    private SFXPlayer _SFXPlayer;
    public ParticleSystem pow;

    void Start() {
        _SFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
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
            other.GetComponent<Player>().health -= damage;
            _SFXPlayer.playPlayerHit();
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile") && isDestructible) {
            _SFXPlayer.playBasicEnemyDestroy();
            pow.Play();
            Destroy(gameObject);
        } else if (other.CompareTag("Projectile") && !isDestructible) {
            _SFXPlayer.playIndestructableHit();
        }
    }
}
