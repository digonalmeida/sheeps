using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SheepAnimationController : MonoBehaviour
{
    //Variables
    private Animator animator;

    //Start
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Check if An Animation has Ended
    public bool checkEndOfAnimation(string animation)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animation))
        {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
        }
        else return false;
    }
}
