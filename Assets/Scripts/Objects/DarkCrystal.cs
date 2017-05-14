using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCrystal : MonoBehaviour {

	public Animator anim;
	public Sprite newSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			if (anim != null) {
				anim.SetBool ("Bool", true);
			}
			gameObject.GetComponent<SpriteRenderer> ().sprite = newSprite;
		}
	}
}
