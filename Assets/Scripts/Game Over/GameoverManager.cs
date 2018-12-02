using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
	
    public void ReStart()
    {
        SceneManager.LoadScene("main");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("gameOver");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("ending");
    }
}
