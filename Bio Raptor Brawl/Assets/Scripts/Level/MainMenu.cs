using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Options()
    {
        print("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
