using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyListener : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
		if(Input.anyKeyDown)
        {
            AudioController.Instance.playSFX(AudioController.Instance.clipSFX_Rooster);
            SceneManager.LoadScene("main");
        }
	}
}
