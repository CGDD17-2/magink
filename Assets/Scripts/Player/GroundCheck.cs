using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private PlayerController player;

	private void Start() {
		player = gameObject.GetComponentInParent<PlayerController>();
	}
	private void OnTriggerEnter2D(Collider2D col) {
		if (!col.isTrigger) {
			player.grounded = true;
			//Debug.Log("GROUNDED!!" + col.gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D col) {
		if (!col.isTrigger) {
			player.grounded = true;
			//Debug.Log("GROUNDED!!" + col.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D col) {
		if (!col.isTrigger) {
			player.grounded = false;
			//Debug.Log("Exit grounded");
		}
	}
}
