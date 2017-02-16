using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;

    private bool pause = false;

    void Awake()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause_P1"))
        {
            pause = !pause;
        }

        if (pause)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!pause)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        pause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
