using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePhoneMessage : MonoBehaviour
{

    public Image icon;
    public LocalizedText localizedText;

    public void Setup(MessageBlob blob)
    {
        icon.sprite = SheepsManager.Instance.GetSheepConfigById(blob.senderID).Icon;
        localizedText.SetupText(blob.messageKey);
    }

}
