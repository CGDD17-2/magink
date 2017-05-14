using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    public GameObject spawnee;
    public float spawnTime;
    public int maxCrates;
    public float lifeTime;
    
	void Start () {
        InvokeRepeating("Spawn", 0.0f, spawnTime);
	}
	
    void Spawn()
    {
        if (transform.childCount < maxCrates)
            Instantiate(spawnee, transform);
        else
            KillOldest();
    }
    
    void KillOldest()
    {
        if(transform.childCount > 0)
            transform.GetChild(0).GetComponent<Crate>().StartDying(lifeTime);
    }
}
