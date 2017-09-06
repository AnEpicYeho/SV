using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject hudMag;
	public GameObject hudAmmo;
	public GameObject hudAccesLevel;	

	public GameObject[] weapons;
	private GameObject activeWeapon;
	private int AccesLevel;
	private int weaponIndex;

	// Use this for initialization

	public int getAccesLevel(){
		return AccesLevel;
	}

	public void upgradeAccesLevel(){
		AccesLevel++;
		showAccesLevel ();
	}

	private void showAccesLevel(){
		hudAccesLevel.GetComponent<Text> ().text = "ACCES TYPE: "+ AccesLevel;
	}

	private void showWeaponStatus(){
		int mag = weapons [weaponIndex].GetComponent<Weapon> ().getMag ();
		int ammo = weapons [weaponIndex].GetComponent<Weapon> ().getAmmo ();

		hudMag.GetComponent<Text> ().text = "MAG: "+mag;
		hudAmmo.GetComponent<Text> ().text = "AMMO: "+ammo;
	
	}


	void Start () {
		showAccesLevel ();
		foreach(GameObject weapon in weapons){
			weapon.SetActive (false);
		}
		weapons [0].SetActive (true);
	}

	private void selectNextWeapon(){
		weapons [weaponIndex].SetActive (false);
		weaponIndex++;
		if(weaponIndex >= weapons.Length){
			weaponIndex = 0;
		}
		weapons [weaponIndex].SetActive (true);

	}

	private void selectPreviousWeapon(){
		weapons [weaponIndex].SetActive (false);
		weaponIndex--;
		if(weaponIndex<0){
			weaponIndex = weapons.Length-1;
		}
		weapons [weaponIndex].SetActive (true);
	}

	private void selectWeapon (){
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		showWeaponStatus ();
		if (Input.mouseScrollDelta.y > 0) {
			selectNextWeapon ();
		} else if(Input.mouseScrollDelta.y < 0) {
			selectPreviousWeapon ();
		}
		
	}
}
