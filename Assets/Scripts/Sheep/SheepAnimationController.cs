using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SheepAnimationController : MonoBehaviour
{
    //Animator Reference
    private Animator animator;

    //Timing Animations
    public float timeAnimationDying = 1f;
    public float timeAnimationAttacking = 1f;
    public float timeAnimationGrabbing = 1f;
    public float timeAnimationStunned = 1f;
    public float timeAnimationUncounscious = 1f;

    //Start
    private void Start()
    {
        animator = GetComponent<Animator>();
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
