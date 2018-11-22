using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 15f;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public bool player;
	public float bulletlifetime= 5f;
	
	void Start () {
		player = PlayerController.CharacterR; //teste para verificar a direção do player
		sr = GetComponent<SpriteRenderer>(); // pegar o sprite da bala	
		Fire(player);
		Destroy(gameObject, bulletlifetime); // Destroi a bala depois de um tempo
	}
	void OnTriggerEnter2D (){
		Destroy(gameObject);
	}
	void Fire(bool Face){ //Define a direção e velocidade da bala
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
