using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLimits : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        SheepState sheep = col.gameObject.GetComponent<SheepState>();
        if (sheep != null)
        {
			WolvesManager.Instance.NotifyWolves(sheep);
        }
    }


}
