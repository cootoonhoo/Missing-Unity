using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	// Pegar o sprie render e flipar na hora do tiro com o sprite do player flipado
	public float speed = 15f;
	public Rigidbody2D rb;
	void Start () {
		rb.velocity = transform.right * speed;
		
	}
	void OnTriggerEnter2D (Collider2D hitInfo){
		Destroy(gameObject);
	}
}
