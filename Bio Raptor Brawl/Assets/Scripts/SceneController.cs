using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public GameObject ReturnToMenuCanvas;

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void MenuSceneConfirmation()
    {
        Time.timeScale = 0;
        ReturnToMenuCanvas.SetActive(true);
    }

    public void RemoveReturnMenuCanvas()
    {
        ReturnToMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
