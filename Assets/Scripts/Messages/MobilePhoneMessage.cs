using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePhoneMessage : MonoBehaviour
{
    public Color playerMessageColor;
    public Color fearMessageColor;
    public RectTransform panel;
    public Image border;
    public Image icon;
    public LocalizedText localizedText;
    public Text sheepName;

    public void Setup(MessageBlob blob)
    {
        SheepConfig config = SheepsManager.Instance.GetSheepConfigById(blob.senderID);
        icon.sprite = config.Icon;
        sheepName.text = config.Name;
        localizedText.SetupText(blob.messageKey);
        if (blob.style == messageStyle.user)
        {
            border.color = playerMessageColor;
        }
        else if (blob.style == messageStyle.alert)
        {
            border.color = fearMessageColor;
        }
        else
        {
            border.color = Color.white;
        }
    }

    public void SetVisibility(bool visible)
    {
        panel.gameObject.SetActive(visible);

    }

}
