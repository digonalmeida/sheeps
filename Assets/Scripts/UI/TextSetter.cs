using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
    public void updateText(string name)
    {
        GetComponent<Text>().text = name;
    }
}
