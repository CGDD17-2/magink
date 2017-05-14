using Prime31.TransitionKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEntry : MonoBehaviour {

    public int index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
			GameManager.instance.LoadLevel (index);
        }
    }
}
