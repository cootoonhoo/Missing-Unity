using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public float speed = 15f;
	public Rigidbody2D rb;
	public float bulletlifetime= 1f;
	private GameObject gb;
	
	void Start () {
		gb = GetComponent<GameObject>();
		if (gb == null){
			Destroy(gameObject, bulletlifetime); // Destroi a bala depois de um tempo
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other != null){
			Destroy(this.gameObject);
		}
	}
	void Fire(){
			rb.velocity = transform.right * -speed;
		}
	}