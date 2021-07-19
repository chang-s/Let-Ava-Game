using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public float timeToExist = .3f;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D> ();
        rb.angularVelocity = -90f;
        rb.velocity = transform.right * 2;
    }

    void Update()
    {
        timeToExist -= Time.deltaTime;

        if (timeToExist < 0) {
            Destroy(gameObject);
        }
    }
}
