using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainMenuBGM;
    private bool mainMenuBGMPaused = false;
    public AudioSource mainGameBGM;
    private bool mainGameBGMPaused = false;
    public AudioSource gameOverBGM;
    private bool gameOverBGMPaused = false;

    public AudioSource basicEnemyDestroy;
    public AudioSource lightEnemyDestroy;
    public AudioSource indestructableHit;
    public AudioSource buttonClick;
    public AudioSource playerHit;
    public AudioSource playerShot;
    public AudioSource playerJump;
    public AudioSource coinCollect;
    public AudioSource heartCollect;
    public AudioSource collectDestroy;

    public void StopBGM() {
        if (mainMenuBGM.isPlaying) {
            mainMenuBGM.Stop();
        }
        
        if (mainGameBGM.isPlaying) {
            mainGameBGM.Stop();
        }

        if (gameOverBGM.isPlaying) {
            gameOverBGM.Stop();
        }
    }
    
    public void PauseBGM() {
        if (mainMenuBGM.isPlaying) {
            mainMenuBGM.Pause();
            mainMenuBGMPaused = true;
        }
        
        if (mainGameBGM.isPlaying) {
            mainGameBGM.Pause();
            mainGameBGMPaused = true;
        }

        if (gameOverBGM.isPlaying) {
            gameOverBGM.Pause();
            gameOverBGMPaused = true;
        }
    }

    public void ResumeBGM() {
        if (mainMenuBGMPaused) {
            mainMenuBGM.UnPause();
        }
        
        if (mainGameBGMPaused) {
            mainGameBGM.UnPause();
        }

        if (gameOverBGMPaused) {
            gameOverBGM.UnPause();
        }
    }
    
    public void PlayMainMenuBGM() {
        StopBGM();
        mainMenuBGM.Play();
    }

    public void PlayMainGameBGM() {
        StopBGM();
        mainGameBGM.Play();
    }

    public void PlayGameOverBGM() {
        StopBGM();
        gameOverBGM.Play();
    }

    public void PlayBasicEnemyDestroy() {
        basicEnemyDestroy.Play();
    }

    public void PlayLightEnemyDestroy() {
        lightEnemyDestroy.Play();
    }

    public void PlayIndestructableHit() {
        indestructableHit.Play();
    }
    
    public void PlayButtonClick() {
        buttonClick.Play();
    }

    public void PlayPlayerHit() {
        playerHit.Play();
    }

    public void PlayPlayerShot() {
        playerShot.Play();
    }

    public void PlayPlayerJump() {
        playerJump.Play();
    }

    public void PlayCoinCollect() {
        coinCollect.Play();
    }

    public void PlayHeartCollect() {
        heartCollect.Play();
    }

    public void PlayCollectDestroy() {
        collectDestroy.Play();
    }
}
