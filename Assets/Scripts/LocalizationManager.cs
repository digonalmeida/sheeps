using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{

    public TextAsset csvFile;
    private Dictionary<string, string> localizedTexts = new Dictionary<string, string>();
    private List<string> languages = new List<string>();
    [SerializeField] private string currentLanguage = "enUS";

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ';'; // It defines field seperate chracter

    protected override void Awake()
    {
        base.Awake();
        ConstructLanguageDict();
    }

    private void ConstructLanguageDict()
    {
        string[] linhas = csvFile.text.Split(lineSeperater);

        string[] linguas = linhas[0].Split(fieldSeperator);
        for (int j = 1; j < linguas.Length; j++)
        {
            languages.Add(linguas[j]);
        }

        for (int i = 1; i < linhas.Length; i++)
        {
            string[] textos = linhas[i].Split(fieldSeperator);
            for (int j = 1; j < textos.Length; j++)
            {
                localizedTexts.Add(textos[0] + "_" + linguas[j], textos[j]);
            }
        }
    }

    public string GetLocalizedText(string messageKey){
        string dictKey = messageKey+"_"+currentLanguage;
        if(localizedTexts.ContainsKey(dictKey)){
            return localizedTexts[dictKey];
        } else {
            return "";
        }
    }

    public void ChangeLanguage(string newLanguage){
        if(languages.Contains(newLanguage)){
            currentLanguage = newLanguage;
            GameEvents.Localization.LanguageChanged.SafeInvoke();
        }
    }
}