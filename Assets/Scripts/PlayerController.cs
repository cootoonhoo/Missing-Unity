using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	SpriteRenderer Sr;
	public float horizontalSpeed = 10f ;
	public float jumpSpeed = 600f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Sr = GetComponent<SpriteRenderer>();		
	}
	
	// Update is called once per frame
	void Update () {
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
	
	void MoveHorizontal(float speed){
	//Adição de força para o movimento, ou seja, mover 
		rb.velocity = new Vector2(speed, rb.velocity.y);
	if(speed <0f){
		Sr.flipX =true; 
	}
	else if(speed > 0f){
		Sr.flipX =false;
		}		
	}
	void StopMovingHorizontal(){
		//Função de "parada" do player
		rb.velocity = new Vector2(0f, rb.velocity.y);
		//if(!isJumping){ "Não temos a função de pulo"
		//	anim.SetInteger("State" , 0);			
		}
}
