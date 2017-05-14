using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;
	public bool cameraRestriction;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
    public float shake;
    public float shakeAmount;
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(shake >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shake -= Time.deltaTime;
        }

	}

    public void shakeCam(float shakePower,float shakeDuration)
    {
        shakeAmount = shakePower;
        shake = shakeDuration;
    }

	private void FixedUpdate() {
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
			
		transform.position = new Vector3(posX, posY+0.1f,transform.position.z);
		if (cameraRestriction) {
			if (transform.position.x > maxX)
				transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
			if (transform.position.x < minX) {
				transform.position = new Vector3(minX, transform.position.y, transform.position.z);
			}
			if (transform.position.y > maxY) {
				transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
			}
			if (transform.position.y < minY) {
				transform.position = new Vector3(transform.position.x, minY, transform.position.z);
			}
		}
	}
}
