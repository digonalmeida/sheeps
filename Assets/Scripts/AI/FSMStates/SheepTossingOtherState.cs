using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepTossingOtherState : FSMState
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
        //Movement
        if (agent.sheepAnimationController.checkEndOfAnimation("Tossing"))
        {
            agent.sheepInputData.targetSheep.GetComponent<SheepController>().getTossed(agent.sheepInputData.lookDirection);
            agent.stateMachine.SetState(agent.sheepIdleState);
        }
    }
}
