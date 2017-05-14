using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{

    public TextAsset textFile;

    public int startLine;
    public int endLine;

    public DialogueManager manager;

    public bool requiredButtonPress;
    private bool waitForPress;

    public bool active;
    public bool destroyWhenActivated;


    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        if (endLine == 0)
            endLine = manager.textLines.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
            if (requiredButtonPress)
                if (waitForPress && Input.GetKeyDown(KeyCode.Return))
                    PlayDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active)
        {
            if (collision.tag == "Player")
            {
                if (requiredButtonPress)
                    waitForPress = true;
                else
                    PlayDialogue();
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            waitForPress = false;
    }

    private void PlayDialogue()
    {
        manager.PlayDialogue(textFile);

        if (!(startLine > manager.textLines.Length || endLine > manager.textLines.Length || startLine > endLine))
        {
            manager.currLine = startLine;
            manager.endLine = endLine;
            manager.EnableTextBox();
        }
        if (destroyWhenActivated)
            Destroy(gameObject);

    }
}
