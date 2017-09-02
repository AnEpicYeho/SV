using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWeapon : MonoBehaviour, Weapon {
	public GameObject bullet;
	public float damange;
	public float shootDistance;
	public float fireRate;
	public int magCapacity;

	private int bulletsOnMag;
	private float timeForNextShoot;

	private int ammo=20;

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
	public void shoot(){
		Instantiate (bullet, transform.GetChild(0).position,transform.GetChild(0).rotation);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxis("Fire1")!=0 && timeForNextShoot<=0){
		}
	}
}
