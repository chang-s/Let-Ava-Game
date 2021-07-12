using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NN_Spawner : MonoBehaviour
{
    public GameObject naughtyNotebook;

    private GameObject _createdNN;

    public float startTimeTillSpawn;
    private float _timeBtwSpawn;

    void Start() {
        _timeBtwSpawn = startTimeTillSpawn;
    }

    void Update() {
        
        if (_timeBtwSpawn <= 0) {
            _createdNN = Instantiate(naughtyNotebook, transform.position, Quaternion.identity);

            
            _timeBtwSpawn = 20;
        } else if (_createdNN == null || !_createdNN.activeInHierarchy) {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }
}
