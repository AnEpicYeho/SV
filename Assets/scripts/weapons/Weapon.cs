using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon {

	void shoot();
	void reload();
	void addAmmo(int ammo);

}
