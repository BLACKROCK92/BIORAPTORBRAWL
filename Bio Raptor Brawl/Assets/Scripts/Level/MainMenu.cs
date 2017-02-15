using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NewGame()
    {
        Application.LoadLevel(1);
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
