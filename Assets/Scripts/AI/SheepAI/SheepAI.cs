using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepState))]
public class SheepAI : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();

    public void Awake()
    {
        stateMachine.Agent = this;
    }

    private void Start()
    {
        //FIX!
        //stateMachine.SetState(stateMachine.sheepIdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
