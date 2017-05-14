using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour {


    public DoorController door;
	private SpriteRenderer spriteRenderer;
	public bool switchable;
	private bool switched;

    // Use this for initialization
    void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		switched = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "LeverTrigger" && (switchable || !switched))
        {
			switched = true;
			if (door != null) {
				door.unlocked = !door.unlocked;
			}
			spriteRenderer.flipX = !spriteRenderer.flipX;
			//if (door.animator != null) {
				//door.animator.SetBool("Unlocked", !door.animator.GetBool ("Unlocked"));
			//}
			//door.gameObject.GetComponent<BoxCollider2D>().isTrigger = !door.gameObject.GetComponent<BoxCollider2D>().isTrigger;
        }
    }
}
