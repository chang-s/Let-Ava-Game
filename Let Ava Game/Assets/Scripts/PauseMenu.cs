using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private SoundManager SoundManager;
    public GameObject PauseUI;

    void Start() {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.resumeBGM();
        isPaused = false;
    }

    void Pause() {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.pauseBGM();
        isPaused = true;
    }
}
