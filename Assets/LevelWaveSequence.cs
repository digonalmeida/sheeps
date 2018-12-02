using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="LevelWaveSequence",menuName="Level Wave",order=0 )]
public class LevelWaveSequence : ScriptableObject {
	public List<TensionCurve> tensionSequence = new List<TensionCurve>();
	public int requiredSacrifices;
}
