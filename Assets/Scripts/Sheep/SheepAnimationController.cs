using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SheepAnimationController : MonoBehaviour
{
    //Timing Animations
    public float timeAnimationDying = 1f;
    public float timeAnimationAttacking = 1f;
    public float timeAnimationGrabbing = 1f;
    public float timeAnimationStunned = 1f;
    public float timeAnimationUncounscious = 1f;
}
