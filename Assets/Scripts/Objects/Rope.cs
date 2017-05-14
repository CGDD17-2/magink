using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public GameObject holdingType;
    private GameObject holding;
    private bool done;

	// Use this for initialization
	void Start () {
        holding = Instantiate(holdingType, transform);
        holding.transform.parent = transform;
        holding.transform.localPosition = new Vector2(0f, -1f);
        holding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        done = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!done)
        {
            if (collision.tag == "Line")
            {
                Debug.Log("TAG IS LINE");
                holding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Destroy(transform.Find("RopeSprite").gameObject);
                done = true;
            }
            if(collision.tag == "Player")
            {
                StartCoroutine(fall());
                done = true;
            }

          
        }
    }

    private IEnumerator fall()
    {
        yield return new WaitForSeconds(0.5f);
        holding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        Destroy(transform.Find("RopeSprite").gameObject);

    }
}
