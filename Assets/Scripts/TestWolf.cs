using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWolf : MonoBehaviour {


	private SheepState sheep;
	public WolfController wolf;
	public bool die = false;
	// Use this for initialization
	void Awake () {
		sheep = GetComponent<SheepState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(die){
			wolf.FollowSheep(sheep);
			die = false;
		}
	}
}
