using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelFlowControl : MonoBehaviour
{

    public List<LevelWaveSequence> wavesSequences;
    private List<TensionCurve> currentTensionSequence;
    private Dictionary<messageType, float> currentMessageTypeDict;

    private float timer = 0f;
    private float tensionValue;
    private float msgRateValue;
    private int sacrificesMade = 0;
    private int sacrificesNeeded = 0;

    private bool gameStarted, gameEnded, victory;

    void OnEnable()
    {
        GameEvents.Sheeps.SheepDied += IncrementSacrificed;
    }

    void OnDisable()
    {
        GameEvents.Sheeps.SheepDied -= IncrementSacrificed;
    }


    private void Start()
    {
        StartTensionFlow(wavesSequences[0]);
    }

    private void Update()
    {
        if (gameStarted && !gameEnded)
        {
            if (sacrificesMade > sacrificesNeeded)
            {
                FinalizeTensionFlow(false);
            }
        }
    }

    private void IncrementSacrificed(SheepConfig config)
    {
        sacrificesMade++;
    }

    public void StartTensionFlow(LevelWaveSequence sequence)
    {
        // reset values
        timer = 0f;
        sacrificesMade = 0;
        gameStarted = true;
        gameEnded = false;
        victory = false;
        foreach (SheepState sheep in SheepsManager.Instance.allSheeps)
        {
            sheep.config.ResetUsedMessages();
        }

        // load sequence
        sacrificesNeeded = sequence.requiredSacrifices;
        currentTensionSequence = new List<TensionCurve>(sequence.tensionSequence);
        currentMessageTypeDict = RebuildMsgTypeDict(currentTensionSequence[0]);

        // activate messages
        MessageFlowController.Instance.StartMessaging();

        // start evaluating values
        StartCoroutine(EvaluateFlow());
    }

    private void FinalizeTensionFlow(bool isVictorious)
    {
        gameEnded = true;
        victory = isVictorious;

        // finalize messages
        MessageFlowController.Instance.StopMessaging();
    }

    IEnumerator EvaluateFlow()
    {
        while (currentTensionSequence.Count > 0)
        {
            if (timer > currentTensionSequence[0].duration)
            {
                timer -= currentTensionSequence[0].duration;
                TensionCurve t = currentTensionSequence[0];
                if (currentTensionSequence.Count <= 1)
                {
                    msgRateValue = currentTensionSequence[0].messageRateCurve.Evaluate(1);
                    tensionValue = currentTensionSequence[0].tensionCurve.Evaluate(1);
                    yield break;
                }
                currentTensionSequence.RemoveAt(0);
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

        FinalizeTensionFlow(false);
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
            if (!result.ContainsKey(tensionCurve.messageCurves[i].messageType))
            {
                result.Add(tensionCurve.messageCurves[i].messageType, 0f);
            }
        }
        return result;
    }

}
