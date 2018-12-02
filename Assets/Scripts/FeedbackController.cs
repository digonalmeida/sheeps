using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackController : MonoBehaviour
{

    [SerializeField]
    private GameObject powFeedback;

    public void Awake()
    {
        GameEvents.Sheeps.OnSheepAttack += ShowPow;
    }

    public void ShowPow(GameObject attacker, GameObject attacked)
    {
        var pow = Instantiate(powFeedback, attacked.transform);
        pow.transform.SetAsLastSibling();
    }

    public void OnDestroy()
    {
        GameEvents.Sheeps.OnSheepAttack -= ShowPow;
    }
}