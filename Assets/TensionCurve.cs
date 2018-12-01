
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="TensionCurve",menuName="Tension Curve",order=0 )]
public class TensionCurve : ScriptableObject
{
    public float duration;
    public AnimationCurve tensionCurve;
	public AnimationCurve messageRateCurve;
    public List<MessageCurve> messages;

}
