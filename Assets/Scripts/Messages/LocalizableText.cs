using UnityEngine;

[CreateAssetMenu(fileName = "localizableText", menuName = "Localizable Text", order = 0)]
public class LocalizableText : ScriptableObject
{
    [SerializeField] private string ptBR;
    [SerializeField] private string enUS;

    public string PtBR
    {
        get
        {
            return ptBR;
        }

    }

    public string EnUS
    {
        get
        {
            return enUS;
        }
    }
}