using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    private State idle = new SheepIdleState();
    
    public void Awake()
    {
        stateMachine.Agent = this;
    }

    private void Start()
    {
        stateMachine.SetState(idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
