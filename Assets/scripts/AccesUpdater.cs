using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesUpdater : MonoBehaviour, Usable {

	public void beingUsed (){
		GameObject.FindObjectOfType<Inventory> ().upgradeAccesLevel ();
		Destroy (this);
	}
}
