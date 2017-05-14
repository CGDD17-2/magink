using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Arrow : MonoBehaviour
{

	public float speed;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start() {
		Destroy(gameObject, 20);
		rb = GetComponent<Rigidbody2D>();
		GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
	}

	// Update is called once per frame
	void Update() {
        if(rb.simulated)
        {
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RaycastHit2D> hitsback = new List<RaycastHit2D>();
            hits = Physics2D.RaycastAll(transform.position, transform.right, 1f).ToList<RaycastHit2D>();
            hitsback = Physics2D.RaycastAll(transform.position, -transform.right, 1f).ToList<RaycastHit2D>();

            bool line = false;

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.tag == "Line")
                {
                    line = true;
                }

            }

            foreach (RaycastHit2D hit in hitsback)
            {
                if (hit.collider.tag == "Line")
                {
                    line = true;
                }

            }

            if (line)
                GetComponent<KillPlayer>().deadly = false;
            else
            {
                GetComponent<KillPlayer>().deadly = true;
            }
            

            if (rb.velocity.magnitude > 0.5) {
			    transform.right = rb.velocity;
		    }

        }

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!collision.isTrigger && collision.tag == "Line") {
            if (rb.gravityScale == 0)
                rb.gravityScale = 0.5f;
            else
                rb.gravityScale += rb.gravityScale * .5f;
		}
		if (!collision.isTrigger && collision.tag != "Player" && collision.tag != "Line" || rb.gravityScale > 4f) {
				//Destroy(gameObject, 1);
			if (rb) {
				rb.isKinematic = true;
				rb.simulated = false;
				rb.bodyType = RigidbodyType2D.Static;
				transform.parent = collision.transform;
			}
			GetComponent<KillPlayer>().deadly = false;
		}
	}
}
	