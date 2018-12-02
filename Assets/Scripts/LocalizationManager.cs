using System.Collections.Generic;
using UnityEngine;

public enum availableLanguages
{
    enUS,
    ptBR
}

public class LocalizationManager : SingletonDestroy<LocalizationManager>
{

    public List<TextAsset> csvFiles;
    private Dictionary<string, string> localizedTexts = new Dictionary<string, string>();
    private List<string> languages = new List<string>();
    [SerializeField] private availableLanguages currentLanguage = availableLanguages.enUS;

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ';'; // It defines field seperate chracter

    protected override void Awake()
    {
        base.Awake();
        ConstructLanguageDict();
    }

    private void ConstructLanguageDict()
    {

        for (int k = 0; k < csvFiles.Count; k++)
        {
            TextAsset csvFile = csvFiles[k];

            string[] linhas = csvFile.text.Split(lineSeperater);

            string[] linguas = linhas[0].Split(fieldSeperator);
            for (int j = 1; j < linguas.Length; j++)
            {
                if (!languages.Contains(linguas[j]))
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
    }

    public string GetLocalizedText(string messageKey)
    {
        string dictKey = messageKey + "_" + currentLanguage.ToString();
        if (localizedTexts.ContainsKey(dictKey))
        {
            return localizedTexts[dictKey];
        }
        else
        {
            return "";
        }
    }

    public availableLanguages GetLanguage()
    {
        return this.currentLanguage;
    }

    public void ChangeLanguage(availableLanguages newLanguage)
    {
        currentLanguage = newLanguage;
        GameEvents.Localization.LanguageChanged.SafeInvoke();
    }

    private void OnValidate()
    {
        GameEvents.Localization.LanguageChanged.SafeInvoke();
    }
}