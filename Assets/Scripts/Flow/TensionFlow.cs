using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TensionFlow : MonoBehaviour
{

    public List<TensionCurve> tensionSequence = new List<TensionCurve>();
    private List<TensionCurve> currentTensionSequence;
    private Dictionary<messageType, float> currentMessageTypeDict;

    private float timer = 0f;
    private float tensionValue;
    private float msgRateValue;


    private void Start()
    {
        StartTensionFlow();
    }


    public void StartTensionFlow()
    {
        StartCoroutine(EvaluateFlow());
    }

    IEnumerator EvaluateFlow()
    {
        timer = 0f;
        currentTensionSequence = new List<TensionCurve>(tensionSequence);
        currentMessageTypeDict = RebuildMsgTypeDict(currentTensionSequence[0]);

        MessageFlowController.Instance.StartMessaging();

        while (currentTensionSequence.Count > 0)
        {
            if (timer > currentTensionSequence[0].duration)
            {
				timer -= currentTensionSequence[0].duration;
                currentTensionSequence.RemoveAt(0);
                if (currentTensionSequence.Count <= 0)
                {
                    yield break;
                }
                currentMessageTypeDict = RebuildMsgTypeDict(currentTensionSequence[0]);
            }

            float perc = timer / currentTensionSequence[0].duration;

            msgRateValue = currentTensionSequence[0].messageRateCurve.Evaluate(perc);
            tensionValue = currentTensionSequence[0].tensionCurve.Evaluate(perc);
            for (int i = 0; i < currentTensionSequence[0].messageCurves.Count; i++)
            {
                currentMessageTypeDict[currentTensionSequence[0].messageCurves[i].messageType] = currentTensionSequence[0].messageCurves[i].curve.Evaluate(perc);
            }

            UpdateMessageFlowController();

            timer += Time.deltaTime;
            yield return null;
        }

        currentMessageTypeDict = null;
        currentTensionSequence = null;

		MessageFlowController.Instance.StopMessaging();

    }

    private void UpdateMessageFlowController()
    {
        MessageFlowController.Instance.ChangeCurrentRate(msgRateValue);
        MessageFlowController.Instance.ChangeCurrentMessageTypes(currentMessageTypeDict);
    }

    private Dictionary<messageType, float> RebuildMsgTypeDict(TensionCurve tensionCurve)
    {
        Dictionary<messageType, float> result = new Dictionary<messageType, float>();
        for (int i = 0; i < tensionCurve.messageCurves.Count; i++)
        {
            result.Add(tensionCurve.messageCurves[i].messageType, 0f);
        }
        return result;
    }

}
