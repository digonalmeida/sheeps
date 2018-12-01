using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIGrabbingState : FSMState
{
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = false;
        agent.InputData.grabThrow = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
