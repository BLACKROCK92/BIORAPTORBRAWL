using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool pause = false;

    void Awake() {
        PauseUI.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Pause_P1")) {
            pause = !pause;
        }

        if (pause) {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!pause) {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume() {
        pause = false;
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void MainMenu()
    {
        Application.LoadLevel(0);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
