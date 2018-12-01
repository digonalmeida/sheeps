using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    private Text text;
    public string key;

    void OnEnable()
    {
        GameEvents.Localization.LanguageChanged += UpdateText;
    }

    void OnDisable()
    {
        GameEvents.Localization.LanguageChanged -= UpdateText;
    }

    // Use this for initialization
    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        text.text = LocalizationManager.Instance.GetLocalizedText(key);
    }

    public void SetupText(string newKey)
    {
        key = newKey;
        UpdateText();
    }
}
