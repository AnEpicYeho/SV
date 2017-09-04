using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private Vector3 searchPosition;
	private bool inSearchPosition;
	private GameObject target;
	public int damange;
	public float speed;

	// Use this for initialization
	void Start () {
		searchPosition = transform.position + new Vector3 (Random.Range(0,3.5f),Random.Range(1,2.5f),Random.Range(2f,3.5f));
		inSearchPosition = false;
		GetComponent<SphereCollider> ().enabled = false;
	}

	void OnTriggerStay(Collider other) {
		if(other.tag == "Enemy"){
			target = other.gameObject;
			GetComponent<SphereCollider> ().enabled = false;
		}

	}

	private void goPosition(Vector3 position){
		transform.LookAt (position);
		transform.Translate (Vector3.forward * speed);
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Vector3.Distance (searchPosition, transform.position) > 0.5f && !inSearchPosition) {
			goPosition (searchPosition);
		} else if (target == null) {
			inSearchPosition = true;
			GetComponent<SphereCollider> ().enabled = true;
		} else {
			goPosition (target.transform.position);
			if(Vector3.Distance(target.transform.position,transform.position)<0.8f){
				target.GetComponent<Character> ().receibeDamange (damange);
				Destroy (this.gameObject);
			}
		}

	}
}
