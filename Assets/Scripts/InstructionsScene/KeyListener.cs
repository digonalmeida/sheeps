using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyListener : MonoBehaviour
{
    //Scene to Load
    public string sceneToLoad;

	// Update is called once per frame
	void Update ()
    {
		if(Input.anyKeyDown)
        {
            if(sceneToLoad.Equals("main")) AudioController.Instance.playSFX(AudioController.Instance.clipSFX_Rooster);
            SceneManager.LoadScene(sceneToLoad);
        }
	}
}
