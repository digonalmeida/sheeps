using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float duration;

	void Start(){
		StartCoroutine(this.WaitAndAct(duration,()=>Destroy(gameObject)));
	}
}
