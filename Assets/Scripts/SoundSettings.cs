using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle musicCheckBox;

    private void Start()
    {
        LoadMusicState();
        LoadVolumeValue();
    }

    private void LoadVolumeValue()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    private void LoadMusicState()
    {
        if (PlayerPrefs.HasKey("musicState"))
        {
            musicCheckBox.isOn = PlayerPrefs.GetInt("musicState") == 1;
        }
    }

    private void SaveMusicState()
    {
        PlayerPrefs.SetInt("musicState", musicCheckBox.isOn ? 1 : 0);
    }

    private void SaveVolumeValue(float value)
    {
        PlayerPrefs.SetFloat("musicVolume", value);
    }

    public  void OnSliderValueChanged()
    {
        musicCheckBox.isOn = true;
        SetMusicVolume();

    }

    public void OnToggleValueChanged()
    {
        if (musicCheckBox.isOn)
        {
            LoadVolumeValue();
            SetMusicVolume();
        }
        else
        {
            mixer.SetFloat("music", -80);
        }
        SaveMusicState();
    }

    // set music by slider
    private void SetMusicVolume()
    {
       float volume = musicSlider.value;
       mixer.SetFloat("music", Mathf.Log10(volume) * 20);

       SaveVolumeValue(volume);
    }

    //// set music by checkbox
    //public void ToggleMusic()
    //{
    //    if (musicCheckBox.isOn)
    //    {
    //        if (PlayerPrefs.HasKey("musicVolume"))
    //        {
    //            LoadVolume();
    //        }
    //        else
    //        {
    //            SetMusicVolume();
    //        }
    //        Debug.Log("toggle on");
    //    }

    //    else
    //    {
    //        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    //        musicSlider.value = 0.0001f;
    //        mixer.SetFloat("music", -80);

    //        Debug.Log("toggle off");
    //    }
    //}

    //private void LoadVolume()
    //{
    //    musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

    //    SetMusicVolume();
    //}
}
