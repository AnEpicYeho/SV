using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damageable {

	private float healt = 100;
	public float armor;

	// Use this for initialization
	void Start () {
		
	}

	public void receibeDamange (float damange){
		damange -= armor;
		healt -= damange;
		if(healt <= 0){
			Destroy (this.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
