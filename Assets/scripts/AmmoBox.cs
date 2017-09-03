using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour, Usable {
	public int maxAmmoToGive;

	public void beingUsed(){
		Inventory inventory = GameObject.FindObjectOfType<Inventory> ();
		foreach(GameObject weapon in inventory.weapons){
			weapon.GetComponent<Weapon>().addAmmo(Random.Range(5,maxAmmoToGive));
		}
		Destroy (this);
	}
}
