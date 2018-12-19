using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Idle - 0
Jump - 1
Run - 2
Falling - 3
Shooting - 4
Hurt - 5  
*/

public class PlayerController : MonoBehaviour {
	public float horizontalSpeed = 10f;
	public float jumpSpeed = 600f;
	public static bool CharacterR; 

	Rigidbody2D rb;
	public SpriteRenderer sr;
	Animator anim;

	float distancia;
	bool isJumping = false;
	public bool isGrounded = false;
	public Transform feet;
	public LayerMask whatIsGround;
	public float feetWidth = 1f;
	public float feetHeight = 0.1f;
	public float distanceL;
	public LayerMask whatisLadder;
	public bool isClimbing = false;
	public float verticalInput;
	public float verticalSpeed = 5f;
	public float FirePointRadius = 0.1f;
	public GameObject BulletPrefab;
	public float lifecount;
	public static int BulletCount = 0;
	public Transform FirePoint;
	[Header("UI Elements")]
	public Image healthbar;
	public Color fullcolor;
	public Color lowcolor;

	[Header("Sound Effects")]
	public AudioClip ShootSoundEffect;
	public AudioClip HurtEffect;

	// Use this for initialization
	void Start () {
		CharacterR = true;
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		distancia = Mathf.Abs(FirePoint.transform.position.x - transform.position.x);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(feet.position, new Vector3(feetWidth, feetHeight, 0f));
		Gizmos.DrawWireSphere(FirePoint.position, FirePointRadius);
	}

	// Update is called once per frame
	void Update () {
		lifecount = GM.instance.Plifes;
		if(this.gameObject.transform.position.y < GM.instance.yLive){
			GM.instance.KillPlayer();			
		}
		ShowHealth();
		//teste para verificar o tiro
		if(Input.GetButtonDown("Fire1")){
			if(BulletCount > 0){ //Verifica se tem bala
			Shot();
			BulletCount --;
			}
		}

		isClimbing = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(feetWidth, feetHeight), 360.0f, whatisLadder);
		if(isClimbing == true){
			verticalInput = Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(rb.velocity.x, verticalInput * verticalSpeed);

		}
		
		isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(feetWidth, feetHeight), 360.0f, whatIsGround);
		float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1: esquerda, 1: direita
		float horizontalPlayerSpeed = horizontalSpeed * horizontalInput;
		if (horizontalPlayerSpeed != 0) {
			MoveHorizontal(horizontalPlayerSpeed);
		}
		else {
			StopMovingHorizontal();
		}

		if (Input.GetButtonDown("Jump")) {
			Jump();
		}
		ShowFalling();
	}

	void MoveHorizontal(float speed) {
		Flip(speed);

		if (!isJumping) {
			anim.SetInteger("State", 2);
		}
	}

	void StopMovingHorizontal() {
		rb.velocity = new Vector2(0f, rb.velocity.y);
		if (!isJumping) {
			anim.SetInteger("State", 0);
		}
	}
	void ShowFalling() {
		if (rb.velocity.y < 0f) {
			anim.SetInteger("State", 3);
		}
	}

	void Jump() {
		if (isGrounded) {
			isJumping = true;
			rb.AddForce(new Vector2(0f, jumpSpeed));
			anim.SetInteger("State", 1);
		}
	}
	void Flip(float speed){
		rb.velocity = new Vector2(speed, rb.velocity.y);
		Vector3 vet = FirePoint.transform.position;

		if (speed < 0f) {
			sr.flipX = true;
			FirePoint.transform.position = new Vector3 (transform.position.x - distancia, vet.y, vet.z);
			CharacterR = false;			
		}
		else if (speed > 0f) {
			sr.flipX = false;
			FirePoint.transform.position = new Vector3 (transform.position.x + distancia, vet.y, vet.z);
			CharacterR = true;	
		}
	}


   	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) { //Logica para o pulo
			isJumping = false;
		}if (other.gameObject.layer == LayerMask.NameToLayer("Ammo")) { // Logica para pegar munição
			BulletCount = BulletCount + 3;
			Destroy(other.gameObject);
		}
		if (other.gameObject.layer == LayerMask.NameToLayer("Healt")) { //Logica para pegar a vida
			lifecount = lifecount + 2;
			if(lifecount > 10f){
				lifecount = 10f;
			}
			Destroy(other.gameObject);
		}
		if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) { // Logica para tomar tiro
			Damaged();
		}
		if (other.gameObject.layer == LayerMask.NameToLayer("LevelComplete")) {
			GM.instance.LevelComplete();
		}
	}
	void Shot(){
	//Logica do tiro - Shootin logic 
	Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
	AudioSource.PlayClipAtPoint(ShootSoundEffect, transform.position);
	if(sr.flipX == true){
	rb.AddForce(new Vector2(150.0f, 0));
		}
	if(sr.flipX == false){
	rb.AddForce(new Vector2(-150.0f, 0));
		}
	}
	void Damaged(){ // Logica do dano
		lifecount = lifecount-- ;
		Instantiate(HurtEffect);
		if(lifecount < 0){
			Die();
		}
	}
	void Die(){
		Destroy(this.gameObject);
	}
	void ShowHealth(){ //Logica da barra de vida
	if(healthbar != null){
		float fillAmount = healthbar.fillAmount;
		healthbar.fillAmount = lifecount * 10 /  100;
		healthbar.color = Color.Lerp(lowcolor, fullcolor, fillAmount);
		}
	}
}