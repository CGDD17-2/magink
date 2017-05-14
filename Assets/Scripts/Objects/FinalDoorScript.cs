using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorScript : MonoBehaviour {

	public Sprite newSprite;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
			gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
	}
}
