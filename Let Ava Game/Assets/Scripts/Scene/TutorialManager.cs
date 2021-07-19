using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject groundSpawner;
    public GameObject airSpawner;
    public GameObject player;
    public float waitTimeVal;
    public float groundToAirWait;
    private float waitTime;
    public float endTutorialTime;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        waitTime = waitTimeVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (popUpIndex > 0 && popUpIndex < popUps.Length) { 
            popUps[popUpIndex-1].SetActive(false);
        }
        if (popUpIndex < popUps.Length) {
            popUps[popUpIndex].SetActive(true);
        }

        if (popUpIndex <= 1) {
            // Teach player how to jump and double jump
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                popUpIndex++;
            }
        } else if(popUpIndex == 2) {
            if (waitTime <= 0) {
                groundSpawner.SetActive(true);
                popUpIndex++;
            } else {
                waitTime -= Time.deltaTime;
            }
        } else if(popUpIndex == 3) {
            if (groundToAirWait <= 0) {
                popUpIndex++;
                groundSpawner.SetActive(false);
                waitTime = waitTimeVal;
            } else {
                groundToAirWait -= Time.deltaTime;
            }
        } else if (popUpIndex == 4) {
            if (waitTime <= 0) {
                popUpIndex++;
            } else {
                waitTime -= Time.deltaTime;
            }
        } else if (popUpIndex == 5) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                popUpIndex++;
                waitTime = waitTimeVal;
            }
        } else if (popUpIndex == 6) {
            if (waitTime <= 0) {
                popUpIndex++;
            } else {
                waitTime -= Time.deltaTime;
            }
        } else if (popUpIndex == 7) {
            airSpawner.SetActive(true);
            popUpIndex++;
            waitTime = waitTimeVal;
        } else if (popUpIndex == 8) {
            if (endTutorialTime <= 0) { 
                popUpIndex++; 
                waitTime = 2f;
            } else {
                endTutorialTime -= Time.deltaTime;
            }
        } else if (popUpIndex >= 9) {
            if (player.transform.position.x > 30) {
                SceneManager.LoadScene("MainMenu"); 
            } else {
                player.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (waitTime <= 0) {
                popUpIndex++;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
