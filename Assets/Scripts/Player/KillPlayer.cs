using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public bool deadly;
   
    private void Start()
    {
        deadly = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
		    if (!other.isTrigger && other.tag == "Player" && deadly) {
			    other.GetComponent<Animator>().PlayInFixedTime("EricDies");
			    other.GetComponent<PlayerController>().enabled = false;
			    other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			    other.GetComponent<CapsuleCollider2D>().enabled = false;
			    FindObjectOfType<Camera>().GetComponent<CameraFollow>().enabled = false;
		    }
        }
	}
}
