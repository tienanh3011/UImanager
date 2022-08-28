using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public GameObject PopupOption;
    public GameObject PopupAbout;
    private GameObject currentpopup;
    public Toggle toggleSound;
    public Toggle toggleMusic;
    public Slider sliderSoundVolume;
    public Slider sliderMusicVolume;

    // Start is called before the first frame update
    void Start()
    {
       
        PopupAbout.SetActive(false);
        PopupOption.SetActive(false);
        GameHelper.instance.SoundController.PlayMusic(SoundName.Music, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickPlay()
    {
        Debug.Log("---------Click Play");
        SceneManager.LoadScene("DEmo2");

    }
    public void OnClickOption()
    {
        PopupOption.SetActive(true);
        currentpopup = PopupOption;
        sliderMusicVolume.value = GameHelper.instance.SoundController.MusicVolume;
        sliderSoundVolume.value = GameHelper.instance.SoundController.SoundVolume;
        toggleMusic.isOn = PlayerPrefs.GetInt("MusicOn", 1);
        toggleSound.isOn = PlayerPrefs.GetInt("SoundOn", 1);
    }
    public void OnClickAbout()
    {
        PopupAbout.SetActive(true);
        currentpopup = PopupAbout;
    }
    public void OnClickBack()
    {
        if (currentpopup != null)
        {
            currentpopup.SetActive(false);
        }
    }
    public void OnSoundToggle()
    {
        if(toggleSound.isOn)
        {
            //Sound off
            GameHelper.instance.SoundController.SoundUpdate(false);
            PlayerPrefs.SetInt("SoundOn", 0);
        }
        else
        {
            GameHelper.instance.SoundController.SoundUpdate(true);
            PlayerPrefs.SetInt("SoundOn", 1);
        }
    }
    public void OnMusicToggle()
    {
        if (toggleMusic.isOn)
        {
            //Music Off
            GameHelper.instance.SoundController.MusicUpdate(false);
            PlayerPrefs.SetInt("MusicOn", 0);
        }
        else
        {
            GameHelper.instance.SoundController.MusicUpdate(true);
            PlayerPrefs.SetInt("MusicOn", 1);
        }
    }
    public void OnSliderSound()
    {
        var _value = sliderSoundVolume.value;

        GameHelper.instance.SoundController.SoundVolume = _value;
        GameHelper.instance.SoundController.SoundVolumeUpdate();
        PlayerPrefs.SetFloat("soundvolume", _value);

    }
    public void OnSliderMusic()
    {
        var _value = sliderMusicVolume.value;

        GameHelper.instance.SoundController.MusicVolume = _value;
        GameHelper.instance.SoundController.MusicVolumeUpdate();
        PlayerPrefs.SetFloat("musicvolume", _value);

    }

}
