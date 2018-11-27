using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 15f;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public bool player;
	public float bulletlifetime= 5f;
	private GameObject gb;
	
	void Start () {
		player = PlayerController.CharacterR; //teste para verificar a direção do player
		sr = GetComponent<SpriteRenderer>(); // pegar o sprite da bala
		gb = GetComponent<GameObject>();	
		Fire(player);
		if (gb == null){
			Destroy(gameObject, bulletlifetime); // Destroi a bala depois de um tempo
		}
	}
	void OnTriggerEnter2D (){
	}
	void Fire(bool Face){ //Define a direção  da bala
		if(Face == true ){
			rb.velocity = transform.right * speed;
			sr.flipX = false;
		}
		else if(Face == false){
			rb.velocity = transform.right * -speed;
			sr.flipX = true;
		}
	}
}
