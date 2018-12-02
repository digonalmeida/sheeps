using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHighlighter : MonoBehaviour
{
    //Variables
    public SpriteRenderer highlight;


    //On Mouse Over => Highlight
    private void OnMouseOver()
    {
        highlight.gameObject.SetActive(true);
        PlayerInput.Instance.target = this.gameObject;
    }

    //On Mouse Exit => Remove Highlight
    private void OnMouseExit()
    {
        highlight.gameObject.SetActive(false);
        if (PlayerInput.Instance.target == this.gameObject && !PlayerInput.Instance.highlightTargetLocked)
        {
            PlayerInput.Instance.target = null;
        }
    }
}
