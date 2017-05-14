using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderFalling : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Vector3.Project(-gameObject.GetComponent<Rigidbody2D>().velocity,Vector2.up).magnitude > 10)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

		
	}

    public void releaseBoulder()
    {
        Debug.Log("im faling!");
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
                    other.GetComponent<Animator>().PlayInFixedTime("EricDies");
                    other.GetComponent<PlayerController>().enabled = false;
                    other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    other.GetComponent<CapsuleCollider2D>().enabled = false;
                    FindObjectOfType<Camera>().GetComponent<CameraFollow>().enabled = false;

        }
        if(other.tag == "Inklet" || other.tag =="Goblin")
        {
            other.enabled = false;
        }
        if(other.tag == "Ground" || other.tag == "Line")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
