using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicLoad : MonoBehaviour
{
    bool active = true;

    private void Start()
    {
        // Set the initial volume to 0
        GetComponent<AudioSource>().volume = 0f;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" && active)
        {
            // Gradually increase the volume over time
            float targetVolume = PlayerPrefs.GetFloat("musicVol", 0);
            float fadeSpeed = 0.5f; // Adjust this value to control the fade speed

            GetComponent<AudioSource>().volume += fadeSpeed * Time.deltaTime;

            // Clamp the volume to the target value to avoid overshooting
            GetComponent<AudioSource>().volume = Mathf.Clamp(GetComponent<AudioSource>().volume, 0, targetVolume);

            // Check if the volume has reached the target value
            if (Mathf.Approximately(GetComponent<AudioSource>().volume, targetVolume))
            {
                active = false;
            }
        }
    }
}
