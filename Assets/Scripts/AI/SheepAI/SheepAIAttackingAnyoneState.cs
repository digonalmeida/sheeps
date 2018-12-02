using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIAttackingAnyoneState : FSMState
{
    GameObject closestTarget;
    Coroutine _routine;
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        agent.InputData.movementDirection = Vector3.zero;
       // agent.InputData.attacking = true;
        agent.InputData.grabThrow = false;
        agent.InputData.moveSpeed = 1.0f;

        var sheeps = GameObject.FindObjectsOfType<SheepController>();
        closestTarget = null;
        float closestDistance = float.MaxValue;

        for(int i = 0; i < sheeps.Length; i++)
        {
            if(sheeps[i].gameObject == agent.gameObject)
            {
                continue;
            }
            var distance = (sheeps[i].transform.position - agent.transform.position).sqrMagnitude;
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = sheeps[i].gameObject;
            }
        }

        _routine = agent.StartCoroutine(AttackRoutine());
        
    }

    public override void Update()
    {
        base.Update();
        
    }

    private IEnumerator AttackRoutine()
    {
        var agent = Agent as SheepAI;
        var target = closestTarget;
        
        for (;;)
        {
            if (target != null)
            {
                agent.InputData.movementDirection = (target.transform.position - agent.transform.position);
                agent.InputData.movementDirection.y = 0;
                agent.InputData.movementDirection = agent.InputData.movementDirection.normalized;
                agent.InputData.targetSheep = target;
            }

            if((agent.transform.position - target.transform.position).sqrMagnitude < 2.0f)
            {
                agent.InputData.targetSheep = target;
                agent.InputData.attacking = true;
                yield return new WaitForSeconds(1.0f);
                agent.InputData.attacking = false;
                agent.ChangeBehaviour();
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
