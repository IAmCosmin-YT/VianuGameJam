using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endMenuManager : MonoBehaviour
{

    [SerializeField] int difficulty = 2;
    [SerializeField] Text difficultyText;
    [SerializeField] int maxwords;

    private void Start()
    {
        maxwords = difficulty * 10;
    }

    // Quit the application
    public void QuitApp()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Restart the current level
    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    // Schimba dificultatea printr-un simplu click!!1!!
    public void DifficultyChanger()
    {
        if (difficulty == 1)
        {
            difficulty++;
            difficultyText.text = "Difficulty: Normal";
            maxwords = 10*difficulty;

        }
        else if (difficulty == 2)
        {
            difficulty++;
            difficultyText.text = "Difficulty: Hard";
            maxwords = 10 * difficulty;

        }
        else if (difficulty == 3)
        {
            difficulty = 1;
            difficultyText.text = "Difficulty: Easy";
            maxwords = 10 * difficulty;
        }
    }
    private void Update()
    {
        PlayerPrefs.SetInt("maxWords", maxwords);
    }
}
