using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

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
	}

	void Start () {
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
		if (Input.mouseScrollDelta.y > 0) {
			selectNextWeapon ();
		} else if(Input.mouseScrollDelta.y < 0) {
			selectPreviousWeapon ();
		}
		
	}

	private void changeActiveWeapon(){
	}
}
