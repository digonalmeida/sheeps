using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
	
    public void ReStart()
    {
        PlayerPrefs.SetString("NextScene", "main");
        SceneManager.LoadSceneAsync("loading");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
