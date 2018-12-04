using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {
    public string menuScene = "menu";
	public void OpenMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
