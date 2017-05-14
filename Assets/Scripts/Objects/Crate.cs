using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
    
    public void StartDying(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }

	private void Update(){
		if (transform.parent != null && transform.parent.tag == "Player") {
			transform.localPosition = new Vector3 (1f, 0f);
		}
	}

}
