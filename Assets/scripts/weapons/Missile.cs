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
		if (target == null) {
			inSearchPosition = true;
			GetComponent<SphereCollider> ().enabled = true;
		} else {
			goPosition (target.transform.position);
			if(Vector3.Distance(target.transform.position,transform.position)<0.8f){
				target.GetComponent<Damageable> ().receibeDamange (damange);
				Destroy (this.gameObject);
			}
		}

	}
}
