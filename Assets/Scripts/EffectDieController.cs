using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDieController : MonoBehaviour {
	public AudioClip SoundEffect;
	public float EffectTime = 1f;
	void Awake () {
		Destroy(gameObject, EffectTime); 
		AudioSource.PlayClipAtPoint(SoundEffect, transform.position);
	}
}