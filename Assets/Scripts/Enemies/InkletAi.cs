using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkletAi : MonoBehaviour
{

    public Transform target;
    public int speed;
    public int rSpeed;
    public float range;
    public SpriteRenderer sr;
    private Transform tf;

    
    void Awake()
    {
        tf = transform;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");

        target = thePlayer.transform;
    }

   
    void Update()
    {
        Vector3 dir = target.position - tf.position;
        dir.z = 0.0f;
        if(target.position.x< tf.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
        if(Vector3.Distance(target.position, tf.position) <= range)
        {
            tf.position += (target.position - tf.position).normalized * speed * Time.deltaTime;
        }
        

    }
}