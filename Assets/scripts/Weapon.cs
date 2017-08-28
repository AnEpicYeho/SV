using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float damange;
	public float shootDistance;
	public float fireRate;
	private float timeForNextShoot;

	// Use this for initialization
	void Start () {
		timeForNextShoot = fireRate;
	}

	private void doDamange(GameObject target){
		print (target.name);
		if(target.GetComponent<Character>()!=null){
			target.GetComponent<Character> ().receibeDamange (damange);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;

		Vector3 direction = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.parent.position,direction,Color.red);

		timeForNextShoot -= Time.deltaTime;

		if(Input.GetAxis("Fire1")!=0 && timeForNextShoot<=0){
			timeForNextShoot = fireRate;

			if(Physics.Raycast(transform.parent.position ,direction, out hit, shootDistance)){
				doDamange (hit.transform.gameObject);
			}
		}

		
	}


}
