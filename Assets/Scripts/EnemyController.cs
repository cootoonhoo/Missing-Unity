using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private int lifecount = 2;
	public GameObject DieEffect;
	public Transform Enemy;
	
	void Start () {
	}
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
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
		Instantiate(DieEffect, Enemy.position, Enemy.rotation);
	}
}
