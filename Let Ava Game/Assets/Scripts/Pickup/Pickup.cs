using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected GameManager gameManager;
    protected SoundManager soundManager;
    protected Player player;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = gameManager.soundManager;
        player = gameManager.player;
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
            PickupEffect();
            Destroy(gameObject);
        }
    }

    protected virtual void PickupEffect() {}
}
