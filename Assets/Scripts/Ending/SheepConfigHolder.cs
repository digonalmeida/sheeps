using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepConfigHolder : MonoBehaviour
{
    public SheepConfig config;

    public void ChangeSprite(Sprite newSprite)
    {
        GetComponent<Image>().sprite = newSprite;
    }
}
