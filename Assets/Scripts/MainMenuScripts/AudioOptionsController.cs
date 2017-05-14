using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsController : MonoBehaviour
{

    public Slider mainVolumeSlider;
    public Slider fxVolumeSlider;
    public Slider musicVolumeSlider;

    // Use this for initialization
    void Start()
    {
        mainVolumeSlider.value = SoundManager.instance.mainVolume;
        fxVolumeSlider.value = SoundManager.instance.fxVolume;
        musicVolumeSlider.value = SoundManager.instance.musicVolume;
    }

    public void ChangeMainVolume()
    {
        SoundManager.instance.ChangeMainVolume(mainVolumeSlider.value);
    }

    public void ChangeFxVolume()
    {
        SoundManager.instance.ChangeFxVolume(fxVolumeSlider.value);
    }

    public void ChangeMusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(musicVolumeSlider.value);
    }
}