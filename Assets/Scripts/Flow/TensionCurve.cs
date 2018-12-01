
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(fileName="TensionCurve",menuName="Tension Curve",order=0 )]
public class TensionCurve : ScriptableObject
{
    public float duration;
    public AnimationCurve tensionCurve;
	public AnimationCurve messageRateCurve;
    public List<MessageCurve> messageCurves;

}
