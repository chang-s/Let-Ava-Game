using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{    
    public GameManager gameManager;
    private Player player;
    private GameObject floor;
    public GameObject splash;
    private float speed = 0;
    Rigidbody2D rb;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.player;
        
        rb = GetComponent<Rigidbody2D> ();
        floor = GameObject.Find("Right Road");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.angularVelocity = -(player.maxProjectileSpeed - speed);
        rb.velocity = transform.right * 10;

        if (transform.position.x > 24 || transform.position.y < 2) {
            GameObject splsh = Instantiate(splash, transform.position + new Vector3(1f, -1.0f, 0.0f), Quaternion.Euler(0, 0, 35));
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Disappears when hits the obstacle
        if (other.CompareTag("Obstacle")) {
            GameObject splsh = Instantiate(splash, transform.position + new Vector3(1f, -1.0f, 0.0f), Quaternion.Euler(0, 0, 35));
            Destroy(gameObject);
        }
    }

    public void setSpeed(float newSpeed) {
        speed = newSpeed;
    }
}
