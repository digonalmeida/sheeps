using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
    public void StartNewGame()
    {
        PlayerPrefs.SetString("NextScene", "main");
        SceneManager.LoadSceneAsync("loading");
    }

    public void ShowCredits()
    {
        SceneManager.LoadSceneAsync("credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
