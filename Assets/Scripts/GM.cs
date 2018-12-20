using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yLive = -10;
	public float PlayerHealth = 10f;
	public int PlayerAmmo = 0;

	PlayerController player;

	public float timeToRespawn = 2f;
	public float timeToKill = 1.5f;
	public Transform spawnPoint;
	public GameObject playerPrefab;
	public UIMannager ui;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}
	
	void Start() {
		if (player == null) {
			RespawnPlayer();
		}
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<PlayerController>();
			}
		}
		if(Input.GetKeyDown(KeyCode.M)){
			ExitToMainMenu();
		}
	}

	public void RestartLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitToMainMenu() {
		LoadScene("Menu");
	}

	public void CloseApp() {
		Application.Quit();
	}

	public void LoadScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
	public void RespawnPlayer() {
		Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public void LevelComplete() {
		Destroy(player.gameObject);
		StartCoroutine(MuteMusic(true, 0.5f));
		ui.levelComplete.SetActive(true);
	}
	public void ShowPanel(GameObject Panel){
		Panel.gameObject.SetActive(true);
	}
	public void HidePanel(GameObject Panel){
		Panel.gameObject.SetActive(false);
	}

	IEnumerator MuteMusic(bool value, float delay) {
		yield return new WaitForSeconds(delay);
		Camera.main.GetComponentInChildren<AudioSource>().mute = value;
	}
	public void KillPlayer(){
		if(player != null){
			AudioSource.PlayClipAtPoint(player.HurtEffect, player.transform.position);
			Destroy(player.gameObject);
			PlayerHealth = PlayerHealth - 2f;
			if(PlayerHealth > 0f ){
				RespawnPlayer();
			}
			else{
				GameOver();
			}
		}
	}
	public void PlayerDamaged(){
		PlayerHealth = PlayerHealth - 2f;
		AudioSource.PlayClipAtPoint(player.HurtEffect, player.transform.position);
		if(PlayerHealth < 0f){
			GameOver();
		}
	}
	public void GameOver(){
		Destroy(player.gameObject);
		StartCoroutine(MuteMusic(true, 0.5f));
		ui.gameOver.SetActive(true);
	}

    public int Score()
    {
        return PlayerAmmo;
    }

}