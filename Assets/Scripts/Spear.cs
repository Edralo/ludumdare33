using UnityEngine;
using System.Collections;

public class Spear : Weapon {

	// Update is called once per frame
	void Update () {
		if(GetComponent<Rigidbody>().velocity != Vector3.zero){
			Quaternion rotation = new Quaternion();
			rotation.SetLookRotation( GetComponent<Rigidbody>().velocity,Vector3.up );
			transform.localRotation = rotation;
		}
	}
}
