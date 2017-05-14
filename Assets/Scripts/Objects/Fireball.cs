using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 20);
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.simulated)
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


            if (rb.velocity.magnitude > 0.5)
            {
                transform.right = rb.velocity;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Line")
        {
            FindObjectOfType<DrawController>().DestroyLine(collision.gameObject.GetComponent<Line>());
        }
        else if (collision.tag == "Inklet")
        {
            collision.gameObject.GetComponent<Ignitor>().LoseHealth();
        }
        else if (!collision.isTrigger && collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
