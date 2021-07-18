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

    public void pauseBGM() {
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

    public void resumeBGM() {
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
    
    public void playMainMenuBGM() {
        mainMenuBGM.Play();
    }

    public void playMainGameBGM() {
        mainGameBGM.Play();
    }

    public void playGameOver() {
        gameOverBGM.Play();
    }

    public void playBasicEnemyDestroy() {
        basicEnemyDestroy.Play();
    }

    public void playLightEnemyDestroy() {
        lightEnemyDestroy.Play();
    }

    public void playIndestructableHit() {
        indestructableHit.Play();
    }
    
    public void playButtonClick() {
        buttonClick.Play();
    }

    public void playPlayerHit() {
        playerHit.Play();
    }

    public void playPlayerShot() {
        playerShot.Play();
    }
    public void playPlayerJump() {
        playerJump.Play();
    }
    public void playCoinCollect() {
        coinCollect.Play();
    }
    public void playHeartCollect() {
        heartCollect.Play();
    }
    public void playCollectDestroy() {
        collectDestroy.Play();
    }
}
