using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSetter : MonoBehaviour
{
	public void setImage(Sprite icon)
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
