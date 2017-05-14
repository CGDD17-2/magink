using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlate : MonoBehaviour {

    public DoorController door;
    private SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
	private int numberofthingsonplate;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		numberofthingsonplate = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (!other.isTrigger && other.tag != "Line")
		{
			numberofthingsonplate += 1;
            spriteRenderer.sprite = downSprite;
            door.unlocked = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
	{
		if (!other.isTrigger && other.tag != "Line")
		{
			spriteRenderer.sprite = downSprite;
			door.unlocked = true;
		}
    }

    private void OnTriggerExit2D(Collider2D other)
	{
		if (door.unlocked && !other.isTrigger)
		{
			numberofthingsonplate -= 1;
			if(numberofthingsonplate == 0 ){
	            door.unlocked = false;
				spriteRenderer.sprite = upSprite;
			}
        }
    }
}
