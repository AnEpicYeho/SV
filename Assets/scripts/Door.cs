using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Usable {
	public int requiredAccesLevel;

	public void beingUsed(){
		if(requiredAccesLevel<=GameObject.FindObjectOfType<Inventory> ().getAccesLevel ()){
			Destroy (this.gameObject);
		}

	}
}
