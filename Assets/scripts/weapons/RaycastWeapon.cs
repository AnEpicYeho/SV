using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour, Weapon {

	public float damange;
	public float shootDistance;
	public float fireRate;
	public int magCapacity;

	private int bulletsOnMag;
	private float timeForNextShoot;
	private GameObject target;

	private int ammo=20;



	// Use this for initialization
	void Start () {
		timeForNextShoot = fireRate;
	}
		
	public void shoot(){

		bulletsOnMag--;
		if(target.GetComponent<Character>()!=null){
			target.GetComponent<Character> ().receibeDamange (damange);
		}
	}

	public void reload(){
		if(ammo>0 && Input.GetKey(KeyCode.R)){
			if(ammo>=magCapacity){
				bulletsOnMag = magCapacity;
				ammo -= magCapacity;

			}else{
				bulletsOnMag += ammo;
				ammo = 0;

			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		reload ();
		print ("mag=" + bulletsOnMag);
		print ("ammo" + ammo);

		RaycastHit hit;

		Vector3 direction = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.parent.position,direction,Color.red);

		timeForNextShoot -= Time.deltaTime;

		if(Input.GetAxis("Fire1")!=0 && timeForNextShoot<=0){
			timeForNextShoot = fireRate;

			if(Physics.Raycast(transform.parent.position ,direction, out hit, shootDistance) && bulletsOnMag>0){
				target = hit.transform.gameObject;
				shoot ();
			}
		}


	}
}
