using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public float duration = 1f;
    
	void Start ()
    {
        GetComponentInChildren<Animator>().speed /= duration;
        StartCoroutine(CreditsEnd());
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

	IEnumerator CreditsEnd()
    {
        yield return new WaitForSeconds(duration);

        GoToMenu();
    }
}
