using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject tutorial, story;
    private DialogManager dialogManager;
    [SerializeField][TextArea(3, 10)] public string[] sentences;
    private bool isActive = false;
    private Color alpha0 = new Color(1f, 1f, 1f, 0f);
    private Color alpha1 = new Color(1f, 1f, 1f, 1f);
    private float fadeDuration = .2f;

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

    public void Tutorial()
    {
        tutorial.SetActive(true);
        isActive = true;
        tutorial.GetComponent<Animator>().SetBool("active", true);
    }

    private void Update()
    {
        if (isActive && Input.anyKeyDown)
        {
            isActive = false;
            tutorial.SetActive(false);
            tutorial.GetComponent<Animator>().SetBool("active", false);

        }
    }

    public void StartStory(){
        story.SetActive(true);
        dialogManager = GetComponent<DialogManager>();
        dialogManager.Story(sentences);
    }
}
