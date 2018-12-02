using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGrabbingOtherState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        agent.lockTarget = true;
        agent.sheepAnimationController.setTrigger("Attack");
    }
}
