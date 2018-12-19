using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float speed = 2f;
	public float turnTime = 1f;
	private float TurnCounter;
	private float stopTime = 0.8f;
	Rigidbody2D rb;
	SpriteRenderer sr;
	private int lifecount = 2;
	public GameObject DieEffect;
	Animator anim;
	public bool ShouldMove;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		TurnCounter = turnTime;
	}
	void Update () {
		TurnCounter -= Time.deltaTime;
		if(ShouldMove){
		Move();
		anim.SetInteger("State", 1);
			if(TurnCounter == 0f){
				ShouldMove = false;
				anim.SetInteger("State", 0);
				stopTime -= Time.deltaTime;
				if(stopTime == 0f){
					ShouldMove = true;
					stopTime = 0.8f;
					TurnCounter = turnTime;
				}
			}
		}
		else{
			anim.SetInteger("State", 0);
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
	void Move(){
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}
	void OnCollisionEnter2D(Collision2D other){
		if (!other.gameObject.CompareTag("Player")){
			Flip();
		}
	}
	void Flip(){
		speed = -speed;
		if(speed < 0 ){
			sr.flipX = true;
		}
		else if (speed > 0){
			sr.flipX = false;
		}
	}
}
