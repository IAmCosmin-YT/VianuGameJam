using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepOnLoad : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Mute(){
        AudioListener.pause = !AudioListener.pause;
    }
}
