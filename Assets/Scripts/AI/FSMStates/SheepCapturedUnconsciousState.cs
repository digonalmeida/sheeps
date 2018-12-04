using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedUnconsciousState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        agent.sheepAnimationController.setBool("Unconscious", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepAnimationController.setBool("Unconscious", false);
    }
}
