using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager gameManager;  
    
    public GameObject naughtyNotebook;
    private GameObject createdNN;
    public GameObject obstacle_ground;
    public GameObject obstacle_ground2;
    public GameObject obstacle_ground3;    
    public GameObject obstacle_air;
    public GameObject obstacle_air2;
    public GameObject heart;
    public GameObject coin;
    public GameObject coinMultipler;

    private float timeBtwSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;
    public float maxDifficultyMinTimeBtwSpawn;
    public float maxDifficultyMaxTimeBtwSpawn;
    public int minAirHeight, maxAirHeight;

    public float startTimeTillNNSpawn;
    private float timeBtwNNSpawn;

    void Start() {
        timeBtwNNSpawn = startTimeTillNNSpawn;
    }

    // Update is called once per frame
    void Update() {
        if (timeBtwSpawn <= 0) {

            GameObject obst;

            float rand1 = Random.value;
            float rand2 = Random.value;
            Vector3 spawnPos;
            // Handle pickups
            if (rand1 < 0.5) {
                float rand_height = Random.Range(1, maxAirHeight);
                
                if (rand2 < 0.85) {
                    obst = coin;
                } else if (rand2 < 0.95) {
                    obst = coinMultipler;
                } else {
                    obst = heart;
                }

                spawnPos = new Vector3(gameManager.rightScreenEdge + 5, gameManager.groundHeight + rand_height, 0.0f);
                Instantiate(obst, spawnPos, Quaternion.identity);

            // Handle Flying Obstacles
            } else if (rand1 < 0.7) {
                
                float rand_height = Random.Range(minAirHeight, maxAirHeight);

                if (rand2 < 0.5) {
                    obst = obstacle_air;
                } else {
                    obst = obstacle_air2;
                }
                
                spawnPos = new Vector3(gameManager.rightScreenEdge + 5, gameManager.groundHeight + rand_height, 0.0f);
                Instantiate(obst, spawnPos, Quaternion.identity);
            
            // Handle Ground obstacles (most common)    
            } else {
                if (rand2 < 0.5) {
                    obst = obstacle_ground;
                } else if (rand2 < 0.9) {
                    obst = obstacle_ground2;
                }
                else {
                    obst = obstacle_ground3;
                }

                spawnPos = new Vector3(gameManager.rightScreenEdge + 5, gameManager.groundHeight, 0.0f);
                Instantiate(obst, spawnPos, Quaternion.identity);
            }

            // Randomly set the time for the next obstacle
            timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        } else {
            timeBtwSpawn -= Time.deltaTime;
        }

        // Handles Naughty Notebook Spawn
        if (timeBtwNNSpawn <= 0) {
            Vector3 spawnPos = new Vector3(gameManager.rightScreenEdge + 5, gameManager.groundHeight, 0.0f);
            createdNN = Instantiate(naughtyNotebook, spawnPos, Quaternion.identity);
            timeBtwNNSpawn = 20;
        } else if (createdNN == null || !createdNN.activeInHierarchy) {
            timeBtwNNSpawn -= Time.deltaTime;
        }

        // Update difficulty
        if (minTimeBtwSpawn > maxDifficultyMinTimeBtwSpawn) {
            minTimeBtwSpawn -= Time.deltaTime * 0.01f;
        }

        if (maxTimeBtwSpawn > maxDifficultyMaxTimeBtwSpawn) {
            maxTimeBtwSpawn -= Time.deltaTime * 0.04f;
        }
    }
}
