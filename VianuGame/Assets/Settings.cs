using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    [SerializeField] Slider Master;
    [SerializeField] float MasterVol;
    [SerializeField] Slider Music;
    [SerializeField] float MusicVol;
    [SerializeField] Slider Sfx;
    [SerializeField] float SfxVol;

    [SerializeField] GameObject audioTab;
    [SerializeField] GameObject videoTab;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] StartManager startManager;

    [SerializeField] PlayerMovement zana;

    [SerializeField] AudioMixer audioMixer;

    //[SerializeField] GameObject[] sfxAudio;
    //[SerializeField] GameObject[] musicAudio;

    const string MIXER_MUSIC = "MusicVolumeParameter";
    const string MIXER_SFX = "SfxVolumeParameter";
    const string MIXER_MASTER = "MasterVolumeParameter";

    [SerializeField] bool audioBool = true;
    [SerializeField] bool video = false;
    
    private void Start()
    {       
        Music.value = PlayerPrefs.GetFloat("musicVol", 0);
        MusicVol = PlayerPrefs.GetFloat("musicVol", 0);
        Master.value = PlayerPrefs.GetFloat("masterVol", 0);
        MasterVol = PlayerPrefs.GetFloat("masterVol", 0);
        Sfx.value = PlayerPrefs.GetFloat("sfxVol", 0);
        SfxVol = PlayerPrefs.GetFloat("sfxVol", 0);
        gameObject.GetComponent<Animator>().speed = 2;


        //sfxAudio = GameObject.FindGameObjectsWithTag("SFX");
        //musicAudio = GameObject.FindGameObjectsWithTag("Music");
    }
    public void MasterVoulme()
    {
        MasterVol = Master.value;
        PlayerPrefs.SetFloat("masterVol", MasterVol);
        audioMixer.SetFloat(MIXER_MASTER, MasterVol);

    }
    public void MusicVoulme()
    {
        MusicVol = Music.value;
        PlayerPrefs.SetFloat("musicVol", MusicVol);
        audioMixer.SetFloat(MIXER_MUSIC, MusicVol);

    }
    public void SFXVoulme()
    {
        SfxVol = Sfx.value;
        PlayerPrefs.SetFloat("sfxVol", SfxVol);
        audioMixer.SetFloat(MIXER_SFX, SfxVol);

    }
    public void AudioTab()
    {
        if (!audioBool && video)
        {
            setInactve(audioTab, true);        
            setInactve(videoTab, false);

            video = false;
            audioBool = true;
        }
    }
    public void VideoTab()
    {
        if (!video && audioBool)
        {
            setInactve(videoTab, true);
            setInactve(audioTab, false);
            audioBool = false;
            video = true;
        }
    }

    private void setInactve(GameObject other, bool otherBool)
    {
        other.SetActive(otherBool);
    }
    private void Update()
    {
        float masterVolume;
        float sfxVolume;
        float musicVolume;
        float _MUTE = -80;

        audioMixer.GetFloat(MIXER_MASTER, out masterVolume);
        audioMixer.GetFloat(MIXER_SFX, out sfxVolume);
        audioMixer.GetFloat(MIXER_MUSIC, out musicVolume);

        if (Mathf.Approximately(masterVolume, -25))
        {
            audioMixer.SetFloat(MIXER_MASTER, _MUTE);
        }

        if (Mathf.Approximately(musicVolume, -25))
        {
            audioMixer.SetFloat(MIXER_MUSIC, _MUTE);
        }

        if (Mathf.Approximately(sfxVolume, -25))
        {
            audioMixer.SetFloat(MIXER_SFX, _MUTE);
        }

        if (startManager != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !startManager.story.activeInHierarchy)
            {
                SettingsOpen();
            }
        }
        else if (loseMenu != null && winMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !loseMenu.activeInHierarchy && !winMenu.activeInHierarchy)
            {
                SettingsOpen();
            }
        }

        if (gameObject.GetComponent<Animator>().GetBool("active"))
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
        
    }
    public void SettingsOpen()
    {
        gameObject.GetComponent<Animator>().SetBool("active", !gameObject.GetComponent<Animator>().GetBool("active"));
        if(zana != null)
        {
            zana.enabled = !gameObject.GetComponent<Animator>().GetBool("active");
        }
    }
}
