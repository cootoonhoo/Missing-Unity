using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	SpriteRenderer Sr;
	public float horizontalSpeed = 5f ;
	public float jumpSpeed = 60f;
	Rigidbody2D rb;
	public Transform feet;
	public float feetWidth = 0.2f;
	public float feetHeight = 0.05f;
	public bool isGrounded;
	public LayerMask WhatIsGround;
	bool isJumping = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();		
	}

	void OnDrawGizmos(){ // Desenhar a hit box do feet
		Gizmos.DrawWireCube(feet.position, new Vector3(feetWidth,feetHeight,0f));
	}	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x,feet.position.y), new Vector2(feetWidth, feetHeight), 360.0f, WhatIsGround); //Teste parar constatar se o personagem esta no chão
		if(isGrounded){//CASO O PLAYER ESTIVER PULANDO, O MOVIMENTO NO EIXO X
			//teste para andar
			float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1 Esquerda, 1 Direita
			float horizontalPlayerSpeed = horizontalSpeed*horizontalInput;
			if(horizontalPlayerSpeed !=0 ){
				MoveHorizontal(horizontalPlayerSpeed);
			}
			else {
				StopMovingHorizontal();
			}
		}

		if(isGrounded){
			if(Input.GetButtonDown("Jump")){
			Jump();
			}
			ShowFalling();

		}
		
	}
	
	void MoveHorizontal(float speed){
		//Movimentação do player no eixo X
		rb.velocity = new Vector2(speed, rb.velocity.y);
	if(speed <0f){
 		Sr.flipX =true; 
 	}
 	else if(speed > 0f){
 		Sr.flipX =false;
 		}
 		if(!isJumping){
 		anim.SetInteger("State" , 2);
 		}

 	}
 	void StopMovingHorizontal(){
		 //Movimentação de parar do player no eixo X
 		rb.velocity = new Vector2(0f, rb.velocity.y);
 		if(!isJumping){
 		anim.SetInteger("State" , 0);
 		}
 	}
		void Jump(){
 		isJumping = true;
 		rb.AddForce(new Vector2(0f, jumpSpeed));
		anim.SetInteger("State" , 1);
 		}
 		void OnCollisionEnter2D(Collision2D other){
 			if (other.gameObject.layer == LayerMask.NameToLayer("Ground")){
 				isJumping = false;
 			}
		}
		void ShowFalling(){
		if (rb.velocity.y <0){
			anim.SetInteger("State", 3);
			}
		}			
}