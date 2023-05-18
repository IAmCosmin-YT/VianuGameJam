using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
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
        StartCoroutine(FadeInTutorial());
        isActive = true;
    }

    private IEnumerator FadeInTutorial()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            tutorial.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tutorial.GetComponent<Image>().color = alpha1;
    }

    private IEnumerator FadeOutTutorial()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            tutorial.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tutorial.SetActive(false);
        isActive = false;
    }

    private void Update()
    {
        if (isActive && Input.anyKeyDown)
        {
            StartCoroutine(FadeOutTutorial());
        }
    }
}
