using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIAttackingTargetState : FSMState
{
    Coroutine _routine;
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        var target = agent.Target;
        if (target == null)
        {
            agent.SetIdle();
            return;
        }
        var state = target.GetComponent<SheepController>().stateMachine.CurrentState;

        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = false;
        agent.InputData.grabThrow = false;
        agent.GetComponent<SheepController>().lockTarget = true;
        _routine = agent.StartCoroutine(AttackRoutine());

    }

    public override void Update()
    {
        base.Update();
        var agent = Agent as SheepAI;
        var target = agent.Target;
        if (target == null)
        {
            agent.SetIdle();
            return;
        }
        var state = target.GetComponent<SheepController>().stateMachine.CurrentState;
        if (state is SheepDeadState || 
            state is SheepStunnedState || 
            state is SheepUnconsciousState)
        {
            agent.SetIdle();
        }
    }
    private IEnumerator AttackRoutine()
    {
        var agent = Agent as SheepAI;
        var target = agent.Target;

        for (;;)
        {
            if (target != null)
            {
                agent.InputData.movementDirection = (target.transform.position - agent.transform.position);
                agent.InputData.movementDirection.y = 0;
                agent.InputData.movementDirection = agent.InputData.movementDirection.normalized;
                agent.InputData.targetSheep = target;
            }

            if ((agent.transform.position - target.transform.position).sqrMagnitude < 1.5f)
            {
                agent.InputData.targetSheep = target;
                agent.InputData.attacking = true;

                yield return new WaitForSeconds(.5f);
                agent.SetIdle();
                yield break;
            }

            yield return null;
        }
    }

    public override void OnExit()
    {
        var agent = Agent as SheepAI;
        agent.InputData.attacking = false;
        base.OnExit();

        if (_routine != null)
        {
            agent.StopCoroutine(_routine);
        }
        agent.GetComponent<SheepController>().lockTarget = false;
    }
}
