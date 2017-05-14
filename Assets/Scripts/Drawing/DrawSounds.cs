using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawSounds : MonoBehaviour {



	public AudioSource erase;
	public AudioSource pen1;
	public AudioSource pen2;
	public AudioSource pen3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int rNum = Random.Range (0, 3);
		if (Input.GetMouseButtonDown (0)) {
			if (rNum == 0) {
				pen1.Play ();
			}
			if (rNum == 1) {
				pen2.Play ();
			}
			if (rNum == 2) {
				pen3.Play ();
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			erase.pitch = Random.Range (0.8f, 1.1f);
			erase.Play ();
		}
	}
}
