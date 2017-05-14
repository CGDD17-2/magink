using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    
    public bool unlocked = false;
    public Sprite newSprite;
	private Animator animator;

    // Use this for initialization
    void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (unlocked) {
			animator.SetBool ("Unlocked", true);
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}else{
			animator.SetBool ("Unlocked", false);
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
    }
}
