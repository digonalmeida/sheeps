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

        AudioController.Instance.playMusic(AudioController.Instance.clipMusic_CalmPhase);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("credits");
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
