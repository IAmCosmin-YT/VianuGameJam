using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject tutorial, story, options;
    private DialogManager dialogManager;
    [SerializeField][TextArea(3, 10)] public string[] sentences;
    private bool isActive = false;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OptionsOpen()
    {
        options.GetComponent<Animator>().SetBool("active", true);
        options.GetComponent<Animator>().speed = 2;
    }
    public void OptionsClose()
    {
        options.GetComponent<Animator>().SetBool("active", false);
    }

    public void Tutorial()
    {
        isActive = true;
        tutorial.GetComponent<Animator>().SetBool("active", true);
    }

    private void Update()
    {
        if (isActive && Input.anyKeyDown)
        {
            isActive = false;
            tutorial.GetComponent<Animator>().SetBool("active", false);
        }
    }

    public void StartStory(){
        story.SetActive(true);
        dialogManager = GetComponent<DialogManager>();
        dialogManager.Story(sentences);
    }
}
