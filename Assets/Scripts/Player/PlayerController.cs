using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 150f;
	public AudioSource step;
	public AudioSource jump;

	public bool grounded;
	private bool hasCrate;

	private Rigidbody2D rb2d;
	private Animator animator;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		hasCrate = false;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool("Ground", grounded);
		animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if(Input.GetAxis("Horizontal") < -0.1f) {
			if (grounded && step.isPlaying == false) {
				step.volume = Random.Range (0.2f, 0.3f);
				step.pitch = Random.Range (0.8f, 1.1f);
				step.Play();

			}
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (Input.GetAxis("Horizontal") > 0.1f) {
			if (grounded && step.isPlaying == false) {
				step.volume = Random.Range (0.2f, 0.4f);
				step.pitch = Random.Range (0.8f, 1.1f);
				step.Play();

			}
			transform.localScale = new Vector3(1, 1, 1);
		}
		if ( (Input.GetButtonDown("Jump") ) && grounded && !hasCrate) {
			rb2d.AddForce(Vector2.up * jumpPower);
			grounded = false;
			jump.Play ();
		}
		if (Input.GetButtonUp ("Action") && hasCrate) {
			foreach (Transform child in transform) {
				if (child.tag == "Crate") {
					child.parent = null;
				}
			}
			hasCrate = false;
		}
	}

	private void FixedUpdate() {

		float input = Input.GetAxis("Horizontal");

		//Slow down player
		rb2d.velocity = new Vector2(rb2d.velocity.x * 0.5f, rb2d.velocity.y);
        
		//Moving player
		rb2d.AddForce((Vector2.right * input) * speed);  
        
		//Limit speed
		if(rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

		}
	}
	public void KillPlayer() {
		GameManager.instance.LoadCurrentLevel();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Crate") {
			gameObject.GetComponent<Animator>().SetBool("Pushing", true);
		}
	}

	private void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Crate" && Input.GetButtonDown ("Action") && !hasCrate) {
			other.transform.parent = transform;
			hasCrate = true;
		}
	}


	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag == "Crate") {
			gameObject.GetComponent<Animator>().SetBool("Pushing", false);
		}
	}
}
