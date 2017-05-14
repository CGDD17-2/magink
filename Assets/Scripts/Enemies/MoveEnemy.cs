using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : PhysicsObject {
    private PlayerPlatformerController player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerPlatformerController>();
    }

	// Update is called once per frame
	void Update () {

        if (OnTriggerEnter2D(player.GetComponent<Collider2D>())){
            targetVelocity = Vector2.right * 3;
        }

        else
        {
        targetVelocity = Vector2.left *3;
        }
		
	}
    bool OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ArcaneEric")
        {
            return false;
        }
        return true;
    }

}
