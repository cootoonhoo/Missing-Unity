using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMannager : MonoBehaviour {
	public Text BulletCount;
	public GameObject levelComplete;
	public GameObject gameOver;
	public int Bullet;

		[Header("Player Elements")]
	public Image healthbar;
	public Color fullcolor;
	public Color lowcolor;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Bullet = PlayerController.BulletCount;
		TextChange();
		ShowHealth();
	}
	 public void TextChange(){
		BulletCount.text = "x " + Bullet; 
	}
	void ShowHealth(){
	if(healthbar != null){
		float fillAmount = healthbar.fillAmount;
		healthbar.fillAmount = GM.instance.PlayerHealth * 10 /  100;
		healthbar.color = Color.Lerp(lowcolor, fullcolor, fillAmount);
		}
	}
	
}
