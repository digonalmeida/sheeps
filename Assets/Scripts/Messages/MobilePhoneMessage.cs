using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePhoneMessage : MonoBehaviour
{

    public RectTransform panel;
    public Image icon;
    public LocalizedText localizedText;

    public void Setup(MessageBlob blob)
    {
        icon.sprite = SheepsManager.Instance.GetSheepConfigById(blob.senderID).Icon;
        localizedText.SetupText(blob.messageKey);
    }

    public void SetVisibility(bool visible)
    {
        panel.gameObject.SetActive(visible);

    }

}
