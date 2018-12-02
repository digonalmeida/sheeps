using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManger : MonoBehaviour
{
    public Button btnEn;
    public Button btnPt;

    private void Start()
    {
        CheckLanguage();
    }

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

    private void CheckLanguage()
    {
        if (LocalizationManager.Instance.GetLanguage() == availableLanguages.enUS)
        {
            btnEn.interactable = false;
            btnPt.interactable = true;
        }
        else
        {
            btnEn.interactable = true;
            btnPt.interactable = false;
        }
    }

    public void SetLanguageEnUs()
    {        
        LocalizationManager.Instance.ChangeLanguage(availableLanguages.enUS);
        CheckLanguage();
    }

    public void SetLanguagePtBr()
    {       
        LocalizationManager.Instance.ChangeLanguage(availableLanguages.ptBR);
        CheckLanguage();
    }
}
