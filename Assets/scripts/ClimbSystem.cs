using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ClimbSystem : MonoBehaviour {

	private float heightFactor = 3.2f;
	private bool isInside;
	public float climbSpeed;

	private FirstPersonController fpsController;

	void OnTriggerEnter(Collider other) {
		if(other.tag== "Climbable"){
			fpsController.enabled = false;
			isInside = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag== "Climbable"){
			fpsController.enabled = true;
			isInside = false;
		}
	}

	// Use this for initialization
	void Start () {
		fpsController = GetComponent<FirstPersonController> ();
	}

	private void climbUp(){
		transform.position += (Vector3.up / heightFactor)*climbSpeed;
	}
	private void climbDown(){
		transform.position += (Vector3.down / heightFactor)*climbSpeed;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(isInside){
			if(Input.GetKey(KeyCode.W)){
				climbUp ();
			}else if(Input.GetKey(KeyCode.S)){
				climbDown ();
			}
		}
	}
}
