using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaughtyNotebook : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject paperplane;
    public GameObject homework;   

    private float timeTillSpawn;
    public float startTimeTillSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;
    public float timeBtwSpawn;
    public float startSpeedOffset;
    private bool hasPaused = false;
    public float pauseTime;
    private float pauseTimeTillRunBack = 0;
    public float runBackXPosFromLeft;
    public float runBackSpeedOffset;
    private float speed;
    private Animator animator; 

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        timeTillSpawn = startTimeTillSpawn;
        speed = gameManager.baseSpeed + startSpeedOffset;
        animator = GetComponent<Animator>();
        animator.SetBool("walkingForward", true);
        animator.SetTrigger("walkForward");
    }

    // Update is called once per frame
    void Update() {
        // When it hits a certain closeness, it first pauses
        if (transform.position.x < (gameManager.leftScreenEdge + runBackXPosFromLeft) && !hasPaused) {
            speed = 0;
            hasPaused = true;
            pauseTimeTillRunBack = pauseTime;
            animator.SetBool("isIdle", true);
        }

        // It stays paused for set time
        if (hasPaused && pauseTimeTillRunBack >= 0) {
            pauseTimeTillRunBack -= Time.deltaTime;
            animator.SetBool("isIdle", true);
        }

        // After pausing it runs back
        if (pauseTimeTillRunBack < 0) {
            speed = gameManager.baseSpeed + runBackSpeedOffset;
            animator.SetBool("isIdle", false);
            animator.SetTrigger("walkBackward");
            animator.SetBool("walkingForward", false);
        }
        
        // Spawns projectiles
        if (timeTillSpawn <= 0) {
            animator.SetTrigger("attack");
            timeTillSpawn = timeBtwSpawn;
            if (Random.value < 0.8) {
                Instantiate(paperplane, transform.position, Quaternion.Euler(0, 0, -35));
            } else {
                Instantiate(homework, transform.position, Quaternion.Euler(0, 0, -35));
            }

            timeTillSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        } else {
            timeTillSpawn -= Time.deltaTime;
        }

        // Movement
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //Removes the NN when it passes behind the spawner
        if (transform.position.x > gameManager.rightScreenEdge + 6) {
            Destroy(gameObject);
        }
    }
}
