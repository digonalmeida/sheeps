using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDyingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        agent.sheepAnimationController.setTrigger("Die");
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_WolfKill);
    }
}
