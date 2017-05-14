using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

    private Text myText;
    public string introText;
    public float textSpeed = 0.02f;
    private IEnumerator coroutine;

    void Start () {
        myText = GetComponent<Text>();
        coroutine = TypeText();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StopCoroutine(coroutine);
            myText.text = introText;
        }
    }

    IEnumerator TypeText () {
        foreach(char i in introText)
        {
            myText.text += i;
            yield return new WaitForSeconds(textSpeed);
        }
	}
}
