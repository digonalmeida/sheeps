using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateTransition
{
    public FSMState TargetState { get; set; }
    public Func<bool> Condition { get; set; }
    public int Trigger { get; set; }
}
