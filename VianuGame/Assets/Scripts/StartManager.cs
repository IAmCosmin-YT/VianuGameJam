using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    private bool isActive = false;
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Mute(){
        AudioListener.pause = !AudioListener.pause;
    }
    public void Tutorial(){
        tutorial.SetActive(true);
        isActive = true;
    }
    private void Update() {
        if(isActive && Input.anyKeyDown){
            tutorial.SetActive(false);
            isActive = false;
        }
    }
}
