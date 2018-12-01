using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHighlighter : MonoBehaviour
{
    //Variables
    public GameObject highlight;

    //On Mouse Over => Highlight
    private void OnMouseOver()
    {
        highlight.SetActive(true);
        PlayerInput.Instance.target = this.gameObject;
    }

    //On Mouse Exit => Remove Highlight
    private void OnMouseExit()
    {
        highlight.SetActive(false);
        if (PlayerInput.Instance.target == this.gameObject && !PlayerInput.Instance.highlightTargetLocked) PlayerInput.Instance.target = null;
    }
}
