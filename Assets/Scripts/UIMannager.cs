using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMannager : MonoBehaviour {
	public Text BulletCount;
	public GameObject levelComplete;
	public GameObject gameOver;
	public int Bullet;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Bullet = PlayerController.BulletCount;
		TextChange();
	}
	 public void TextChange(){
		BulletCount.text = "x " + Bullet; 
	}
	
}
