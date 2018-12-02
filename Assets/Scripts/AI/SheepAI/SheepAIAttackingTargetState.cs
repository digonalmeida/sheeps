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
        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = false;
        agent.InputData.grabThrow = false;

        _routine = agent.StartCoroutine(AttackRoutine());
    }


    private IEnumerator AttackRoutine()
    {
        var agent = Agent as SheepAI;
        var target = agent.SpecialTarget;

        for (;;)
        {
            if (target != null)
            {
                agent.InputData.movementDirection = (target.transform.position - agent.transform.position);
                agent.InputData.movementDirection.y = 0;
                agent.InputData.movementDirection = agent.InputData.movementDirection.normalized;
                agent.InputData.targetSheep = target;
            }

            if ((agent.transform.position - target.transform.position).sqrMagnitude < 1.0f)
            {
                agent.InputData.targetSheep = target;
                for(int i = 0; i < 4; i++)
                {
                    agent.InputData.attacking = true;
                    yield return null;
                    //agent.InputData.grabThrow = true;
                    //yield return new WaitForSeconds(.5f);
                }
                agent.ChangeBehaviour();
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
    }
}
