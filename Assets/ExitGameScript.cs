using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameScript : MonoBehaviour
{
    public void Exit() {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(0);
    }

    public void GoToTwitter()
    {
        Application.OpenURL("https://twitter.com/gabrielfpaula");
    }
}
