using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignitor : MonoBehaviour {

    public Fireball projectilePrefab;
    public Transform firePosition;
    public Transform target;
    public float shotSpeed;
    public float shotFrequency;
    public int health;
    public GameObject[] points;
    public GameObject dialogueBox;
    //public ActivateDialogue deathrant;

    private int targetPoint;
    private Rigidbody2D rb;
    private bool fighting;
    private bool turningLeft;

	// Use this for initialization
	void Start () {
        fighting = false;
        turningLeft = true;
        
        StartFight();
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartFight()
    {
        fighting = true;
        GetComponent<Animator>().SetBool("Shooting", true);
        GetComponent<Animator>().speed = shotFrequency;
        InvokeRepeating("ChangeLocation", 0, 10f);
    }

    // Update is called once per frame
    void Update () {
        if (fighting)
        {
            if ((transform.position.x > target.position.x && !turningLeft) ||
                    (transform.position.x < target.position.x && turningLeft))
            {
                turningLeft = !turningLeft;
                transform.localScale = new Vector3(transform.localScale.x * - 1, transform.localScale.y, transform.localScale.z);
            }
        }
	}

    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            fighting = false;
            //deathrant.active = true;
        }
    }

    public void ChangeLocation()
    {
        GetRandomTarget();

        Vector3 dir = points[targetPoint].transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(dir * 100f);
    }

    void GetRandomTarget()
    {
        int tmp = Random.Range(0, points.Length);
        if (tmp != targetPoint)
            targetPoint = tmp;
        else
            GetRandomTarget();
    }

    public void Shoot()
    {

        if (target != null)
        {
            if (projectilePrefab != null)
            {
                // MAAAAAAAAAAAATH
                Fireball projectile = Instantiate(projectilePrefab);
                projectile.transform.position = firePosition.position;
                if (shotSpeed > 0)
                    projectile.speed = shotSpeed;
                Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.up));

                projectile.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
                if (transform.position.x > target.position.x)
                    projectile.transform.rotation *= Quaternion.Euler(0, 180f, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FlightZone")
        {
            rb.velocity = Vector3.zero;
        }
    }
}
