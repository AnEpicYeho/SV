using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;

		Vector3 direction = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.parent.position,direction,Color.red);

		if(Input.GetKey(KeyCode.F) && Physics.Raycast(transform.position ,direction, out hit,10)){
			Usable usable = hit.transform.GetComponent<Usable>();
				if(usable!=null){
				usable.beingUsed ();
				}
			}
		
		}
}
