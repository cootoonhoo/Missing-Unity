using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
	public GameObject panel;
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
			GM.instance.ShowPanel(panel);
		}

	}
}
