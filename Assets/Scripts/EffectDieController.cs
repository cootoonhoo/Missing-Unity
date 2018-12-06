using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDieController : MonoBehaviour {
	public float EffectTime = 1f;
	void Awake () {
		Destroy(gameObject, EffectTime); 
	}
}