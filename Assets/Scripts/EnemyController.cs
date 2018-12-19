using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private int lifecount = 2;
	public GameObject DieEffect;
	public GameObject Bullet;

	public float FireRate = 1f;
	private float TimeToShoot;

	void Start () {
		FireRate = TimeToShoot;
	}
	void Update () {
		if(TimeToShoot == 0f ){
			Instantiate(Bullet, transform.position, Quaternion.identity);
			TimeToShoot = FireRate;
		}
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
