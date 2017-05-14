using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuake : MonoBehaviour {

    public CameraFollow cam;
    public BoulderFalling[] boulder;
    bool okToKillMe = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

            if (okToKillMe)
            {
                Destroy(gameObject);

            }
            if (other.name == "Player")
            {
                cam.shakeCam(0.1f, 2);
                StartCoroutine(fall());
                
            }
    }

    private IEnumerator fall()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < boulder.Length; i++)
            boulder[i].releaseBoulder();
        okToKillMe = true;
        

    }
}
