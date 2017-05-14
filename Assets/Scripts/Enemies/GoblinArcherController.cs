using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherController : MonoBehaviour {
    public enum Direction { left, right, both };

    public Arrow arrowPrefab;
    public Transform firePosition;
    public float shotFrequency;
    public float shotSpeed;
	public AudioSource arrowSound;
    public Direction shootingDirection;

    [SerializeField] private Transform archerTop;

    private bool turningLeft;
    private Transform target;
    private Quaternion defaultRotation;

	// Use this for initialization
	void Start () {
        turningLeft = true;
        //InvokeRepeating("ShootArrow",0.1f, shotInterval);
        if (archerTop != null)
            defaultRotation = archerTop.rotation;
		gameObject.GetComponentInChildren<Animator>().SetFloat("ShotInterval", shotFrequency);
    }

    // Update is called once per frame
    void Update () {
        if (target != null)
        {
            if ((transform.position.x > target.position.x && !turningLeft) || 
                (transform.position.x < target.position.x && turningLeft))
            {
                turningLeft = !turningLeft;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
            }

            if (archerTop != null) 
            {
                Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.up));
                archerTop.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            }
            if ((turningLeft && shootingDirection == Direction.left) || 
                (!turningLeft && shootingDirection == Direction.right) || 
                shootingDirection == Direction.both)
            {
                gameObject.GetComponentInChildren<Animator>().SetBool("Shooting", true);
            } 
            else
                gameObject.GetComponentInChildren<Animator>().SetBool("Shooting", false);

        }
        else
        {

			gameObject.GetComponentInChildren<Animator>().SetBool("Shooting", false);
			if (archerTop != null)
                if (archerTop.rotation != defaultRotation)
                    archerTop.rotation = defaultRotation;
        }
    }

    public void ShootArrow()
    {

		if (target != null) {
			if (arrowPrefab != null) {
				// MAAAAAAAAAAAATH
				Arrow arrow = Instantiate(arrowPrefab);
				arrow.transform.position = firePosition.position;
				if (shotSpeed > 0)
					arrow.speed = shotSpeed;
				Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.up));

				arrow.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
				if (transform.position.x > target.position.x)
					arrow.transform.rotation *= Quaternion.Euler(0, 180f, 0);

				arrowSound.Play();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            target = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            target = null;
    }
}
