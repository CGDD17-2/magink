using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjects : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.tag != "Player" && !collision.isTrigger && collision.tag != "Line")
            Destroy(collision.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.tag != "Player" && !collision.isTrigger && collision.tag != "Line")
            Destroy(collision.gameObject);
    }
}
