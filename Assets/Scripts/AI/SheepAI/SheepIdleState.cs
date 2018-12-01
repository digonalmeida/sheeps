using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIdleState : State
{
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        Debug.Log("entered");
    }

    public override void OnExit()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        Debug.Log("exit");
    }

    public override void Update()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        Debug.Log("update");
    }
}
