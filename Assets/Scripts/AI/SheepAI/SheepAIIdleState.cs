using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIIdleState : FSMState
{
    Coroutine _coroutine;
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;

        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = false;
        agent.InputData.grabThrow = false;
        agent.InputData.targetSheep = null;
        agent.InputData.moveSpeed = 0.1f;
        agent.InputData.movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        _coroutine = agent.StartCoroutine(IdleWait());
    }

    public override void Update()
    {
        base.Update();
    }

    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(Random.Range(.5f, 1.0f));
        var agent = Agent as SheepAI;

        switch(agent.CurrentStrategy)
        {
            case SheepAI.Strategy.AttackAny:
                agent.Target = FindClosestTarget();
                break;
            case SheepAI.Strategy.AttackPlayer:
                agent.Target = PlayerInput.Instance.gameObject;
                break;
            case SheepAI.Strategy.Idle:
                agent.Target = null;
                break;
        }

        if(agent.Target != null)
        {
            agent.SetAttacking();
        }
        else
        {
            agent.SetIdle();
        }
        
    }

    public GameObject FindClosestTarget()
    {
        var sheeps = GameObject.FindObjectsOfType<SheepController>();
        GameObject closestTarget = null;
        float closestDistance = float.MaxValue;
        var agent = Agent as SheepAI;

        for (int i = 0; i < sheeps.Length; i++)
        {
            if (sheeps[i].gameObject == agent.gameObject)
            {
                continue;
            }
            var distance = (sheeps[i].transform.position - agent.transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = sheeps[i].gameObject;
            }
        }

        return closestTarget;
    }
    public override void OnExit()
    {
        base.OnExit();
        var agent = Agent as SheepAI;
        agent.InputData.moveSpeed = 1.0f;
        if(_coroutine != null)
        {
            agent.StopCoroutine(_coroutine);
        }
    }
}
