using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour {

    public AudioClip music;

    void Start () {
        // Set Music
        if (SoundManager.instance != null)
        {
            if (SoundManager.instance.musicSource.clip != music)
                SoundManager.instance.PlayMusic(music);
        }
    }
	
}
