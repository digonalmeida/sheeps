using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimationController : MonoBehaviour
{
    //Animator Reference
    [SerializeField]
    private Animator animator;
    public SpriteRenderer spriteRenderer;
    public ParticleSystemRenderer particleSystemRenderer;

    //Timing Animations
    public float timeAnimationStunned;
    public float timeAnimationUncounscious;
    public float struggleTime;
    public float wolfFightTime;

    //Start
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void setTrigger(string id)
    {
        animator.SetTrigger(id);
    }

    public void setBool(string id, bool value)
    {
        animator.SetBool(id, value);
    }
}
