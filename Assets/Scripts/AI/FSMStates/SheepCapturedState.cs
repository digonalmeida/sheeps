using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
    }
}
