using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIAttackingAnyoneState : FSMState
{
    GameObject closestTarget;
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = true;
        agent.InputData.grabThrow = false;

        var sheeps = GameObject.FindObjectsOfType<MockSheep>();
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
        
    }

    public override void Update()
    {
        base.Update();
        var agent = Agent as SheepAI;
        var target = closestTarget;
        if (target != null)
        {
            agent.InputData.movementDirection = (target.transform.position - agent.transform.position);
            agent.InputData.movementDirection.y = 0;
            agent.InputData.movementDirection = agent.InputData.movementDirection.normalized;
            Debug.Log(closestTarget.name);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
