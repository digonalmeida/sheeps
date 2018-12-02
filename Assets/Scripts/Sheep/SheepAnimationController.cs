using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimationController : MonoBehaviour
{
    //Animator Reference
    [SerializeField]
    private Animator animator;

    //Timing Animations
    public float timeAnimationStunned = 1f;
    public float timeAnimationUncounscious = 1f;
    public float struggleTime = 1f;

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
