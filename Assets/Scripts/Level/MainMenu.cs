using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public AudioClip music;

	// Use this for initialization
	void Start () {
        // Set Music
        if(SoundManager.instance != null)
            SoundManager.instance.PlayMusic(music);
    }
}
