using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementState : FSMState
{
    //Control Variables
    private Vector3 target;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        target = agent.transform.position;
        agent.sheepMovementController.CanMove = true;
        agent.sheepAnimationController.setBool("Walking", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepMovementController.CanMove = false;
        agent.sheepAnimationController.setBool("Walking", false);
    }
}
