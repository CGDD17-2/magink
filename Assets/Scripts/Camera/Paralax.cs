using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parlaxScales;
    public float smoothing = 1f;


    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }
	// Use this for initialization
	void Start () {
        previousCamPos = cam.position;
        parlaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parlaxScales[i] = backgrounds[i].position.z * -1;
        }

        	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < backgrounds.Length; i++)
        {
            float paralax = (previousCamPos.x - cam.position.x) *parlaxScales[i]; 
            float backGroundTargetPosX = backgrounds[i].position.x + paralax;
            Vector3 backgroundTargetPos = new Vector3(backGroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing * Time.deltaTime);


        }
        previousCamPos = cam.position;
	}
}
