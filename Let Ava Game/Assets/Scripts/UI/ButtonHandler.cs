using UnityEngine;
using UnityEngine.SceneManagement;  

// This is general class used for buttons that do not require access to any other
//object. If it is touching a other object (and requires a start() or update()) then make a
// seperate script.
public class ButtonHandler : MonoBehaviour
{    
    public void exitGame() {
        Application.Quit();
    }

    public void startGame() {
        SceneManager.LoadScene("Main");
    }  

    public void tutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
