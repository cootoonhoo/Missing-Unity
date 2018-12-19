using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private int lifecount = 2;
	public GameObject DieEffect;
	void Start () {
	}
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Shoot") {
			Damage();
		}
	}
	void Damage(){
		lifecount --;
		if(lifecount <= 0){
			Die();
		}
	}
	void Die(){
		Destroy(this.gameObject);
		Instantiate(DieEffect, gameObject.transform.position,  gameObject.transform.rotation);
	}
}
