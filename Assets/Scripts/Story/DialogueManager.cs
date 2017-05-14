using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public Image theHead;
    public TextAsset textFile;
    public string[] textLines;
    public int[] headLines;
    public Sprite[] headImages;

    public int currLine;
    public int endLine;

    public bool isActive;

    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;

        FillVariables();

        if (isActive)
            EnableTextBox();
        else
            DisableTextBox();
    }

    void Update()
    {
        if (!isActive)
           return;

        theText.text = textLines[currLine];
        theHead.sprite = headImages[headLines[currLine]];

        if (Input.anyKeyDown)
            currLine++;

        if (currLine > endLine)
            DisableTextBox();
        if (endLine == 0 || endLine > textLines.Length - 1)
            endLine = textLines.Length - 1;

    }

    public void EnableTextBox()
    {
        if (player != null)
        {
            player.GetComponent<Animator>().PlayInFixedTime("EricTalk");
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        isActive = true;
        textBox.SetActive(true);

    }
    public void DisableTextBox()
    {
        if (player != null)
        {
            player.GetComponent<Animator>().PlayInFixedTime("EridIdle");
            player.GetComponent<PlayerController>().enabled = true;
        }

        isActive = false;
        textBox.SetActive(false);
    }

    public void PlayDialogue(TextAsset textFile)
    {
        this.textFile = textFile;

        FillVariables();
    }
    private void FillVariables()
    {
        if (textFile != null && headImages != null)
        {
            textLines = textFile.text.Split('\n');
            headLines = new int[textLines.Length];

            for (int i = 0; i < textLines.Length; i++)
            {
                string[] split = textLines[i].Split(':');
                if (split.Length == 2)
                {
                    headLines[i] = int.Parse(split[0]);
                    textLines[i] = split[1];
                }
                else
                {
                    headLines[i] = 0;
                    textLines[i] = "";
                }
            }
        }
    }
}