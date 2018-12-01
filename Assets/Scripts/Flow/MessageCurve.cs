
using UnityEngine;

[CreateAssetMenu(fileName="MessageCurve",menuName="Message Curve",order=0 )]
public class MessageCurve : ScriptableObject
{
    public messageType messageType;
    public AnimationCurve curve;
}
