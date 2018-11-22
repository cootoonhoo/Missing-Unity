using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	public Transform FirePoint;
	public GameObject BulletPrefab;

	// Passar isso para player controler

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Shot();
		}			
	}

	void Shot(){
		//Logica do tiro - Shootin logic 
		Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
	}
}
