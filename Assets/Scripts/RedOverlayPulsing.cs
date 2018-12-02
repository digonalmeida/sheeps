using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOverlayPulsing : MonoBehaviour
{

    private Animator animator;
    private LevelFlowControl levelFlowControl;
    public float timerPercentageToBlink = 0.7f;
    public float maxBlinkSpeed = 5;
    private bool isBlinking = false;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        levelFlowControl = GetComponentInParent<LevelFlowControl>();
    }

    void Update()
    {
        if (levelFlowControl.GameStarted && !levelFlowControl.GameEnded && levelFlowControl.WaveTimerPerc > timerPercentageToBlink)
        {
            if (!isBlinking)
            {
                StartPulsing();
            }
        }
        else
        {
            StopPulsing();
        }

        if (isBlinking)
        {
            UpdateRate(maxBlinkSpeed * (levelFlowControl.WaveTimerPerc- timerPercentageToBlink)/(1-timerPercentageToBlink));

        }
    }

    void StartPulsing()
    {
        isBlinking = true;
        animator.SetBool("pulsing", true);
		GameEvents.Notifications.StartWarning.SafeInvoke();
    }

    void StopPulsing()
    {
        isBlinking = false;
        animator.SetBool("pulsing", false);
    }

    void UpdateRate(float val)
    {
        animator.SetFloat("vel", val);
		GameEvents.Notifications.StopWarning.SafeInvoke();
    }
}
