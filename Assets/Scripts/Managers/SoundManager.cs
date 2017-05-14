using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource fxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    public float mainVolume;
    public float fxVolume;
    public float musicVolume;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


        mainVolume = AudioListener.volume;
        fxVolume = fxSource.volume;
        musicVolume = musicSource.volume;
    }

    public void PlayFx(AudioClip clip)
    {
        fxSource.clip = clip;
        fxSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void RandomizFx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        fxSource.pitch = randomPitch;
        fxSource.clip = clips[randomIndex];
        fxSource.Play();
    }
    
    public void ChangeMainVolume(float volume)
    {
        mainVolume = volume;
        AudioListener.volume = mainVolume;
    }
    public void ChangeFxVolume(float volume)
    {
        fxVolume = volume;
        fxSource.volume = fxVolume;
    }
    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = musicVolume;
    }

}
