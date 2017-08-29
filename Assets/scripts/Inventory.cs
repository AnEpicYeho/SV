using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject[] weapons;
	private GameObject activeWeapon;
	private int AccesLevel;

	// Use this for initialization

	public int getAccesLevel(){
		return AccesLevel;
	}

	void Start () {
		
	}

	private void selectNextWeapon(){
	
	}

	private void selectPreviousWeapon(){

	}

	private void selectWeapon (){
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	private void changeActiveWeapon(){
	}
}
