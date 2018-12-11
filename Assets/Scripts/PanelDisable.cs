using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisable : MonoBehaviour {

	public GameObject panel;
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
			GM.instance.HidePanel(panel);
		}

	}
}
