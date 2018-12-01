using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRecoveringState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
    }

    public override void Update()
    {
        if (agent.sheepAnimationController.checkEndOfAnimation("Recovering"))
        {
            agent.stateMachine.SetState(agent.sheepIdleState);
        }
    }
}
