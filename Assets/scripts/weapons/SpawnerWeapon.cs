using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWeapon : MonoBehaviour, Weapon {
	public GameObject bullet;
	public float fireRate;
	public int magCapacity;

	private int bulletsOnMag;
	private float timeForNextShoot;

	public int maxAmmo;
	private int ammo;

	public int getAmmo(){
		return ammo;
	}

	public int getMag(){
		return bulletsOnMag;
	}	

	public void addAmmo(int ammo){
		if(ammo+this.ammo<maxAmmo){
			this.ammo += ammo;
		}else{
			this.ammo = maxAmmo;
		}

	}

	public void reload(){
		if(ammo>0 && Input.GetKey(KeyCode.R)){
			if (ammo >= magCapacity) {
				ammo -= magCapacity - bulletsOnMag;
				bulletsOnMag = magCapacity;
			} else {
				bulletsOnMag += ammo;
				ammo = 0;
			}
		}
	}

	public void shoot(){
		bulletsOnMag--;
		Instantiate(bullet, transform.GetChild(0).position,transform.GetChild(0).rotation);
		timeForNextShoot = fireRate;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		reload ();
		print ("mag=" + bulletsOnMag);
		print ("ammo" + ammo);
		timeForNextShoot -= Time.deltaTime;
		if(Input.GetAxis("Fire1")!=0 && timeForNextShoot<=0 && bulletsOnMag>0){
			while(bulletsOnMag>0){
				shoot ();
			}
		}
	}
}
