using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject tutorial, story, options, credits;
    private DialogManager dialogManager;
    [SerializeField][TextArea(3, 10)] public string[] sentences;
    private bool isActive = false;
    private bool isActiveCredits = false;


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
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
        tutorial.GetComponent<Animator>().speed = 2.5f;
        tutorial.GetComponent<Animator>().SetBool("active", true);
    }
    public void Credits()
    {
        isActiveCredits = true;
        credits.GetComponent<Animator>().speed = 2.5f;
        credits.GetComponent<Animator>().SetBool("active", true);
    }

    private void Update()
    {
        if (isActive && Input.anyKeyDown)
        {
            isActive = false;
            tutorial.GetComponent<Animator>().SetBool("active", false);
        }
        if (isActiveCredits && Input.anyKeyDown)
        {
            isActiveCredits = false;
            credits.GetComponent<Animator>().SetBool("active", false);
        }
    }

    public void StartStory(){
        story.SetActive(true);
        dialogManager = GetComponent<DialogManager>();
        dialogManager.Story(sentences);
    }
}
