using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallPickup : MonoBehaviour
{

    private DrawController cont;

    void Start()
    {
        cont = FindObjectOfType<DrawController>();
        gameObject.SetActive(true);
        Cursor.visible = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GivePlayerDrawing(2000f, 2);
            GetComponent<ActivateDialogue>().active = true;
            gameObject.SetActive(false);
        }
    }

    void GivePlayerDrawing(float maginkPool, int numberOfLines)
    {
        cont.initialMaginkPool = maginkPool;
        cont.maginkPool = maginkPool;
        cont.numberOfLines = numberOfLines;
        Cursor.visible = true;
    }
}
