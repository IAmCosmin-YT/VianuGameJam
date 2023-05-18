using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endMenuManager : MonoBehaviour
{

    [SerializeField]int maxWords;
    [SerializeField]int difficulty = 2;
    [SerializeField]Text difficultyText;
    [SerializeField]Text difficultyTextWin;

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
    public void DifficultyChange()
    {
        if(difficulty == 1)
        {
            difficulty++;
            PlayerPrefs.SetInt("difficulty", difficulty);
        }
        else if(difficulty == 2)
        {
            difficulty++;
            PlayerPrefs.SetInt("difficulty", difficulty);

        }
        else if(difficulty == 3)
        {
            difficulty = 1;
            PlayerPrefs.SetInt("difficulty", difficulty);

        }
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("difficulty") == 0)
        {
            PlayerPrefs.SetInt("difficulty", difficulty);
        }
    }
    private void Update()
    {
        if(PlayerPrefs.GetInt("difficulty") == 1)
        {
            PlayerPrefs.SetString("difficultyText", "Difficulty: Easy");
        }
        else if(PlayerPrefs.GetInt("difficulty") == 2)
        {
            PlayerPrefs.SetString("difficultyText", "Difficulty: Normal");
        }
        else if(PlayerPrefs.GetInt("difficulty") == 3)
        {
            PlayerPrefs.SetString("difficultyText", "Difficulty: Hard");
        }
        maxWords = 10 * PlayerPrefs.GetInt("difficulty");
        difficultyText.text = PlayerPrefs.GetString("difficultyText");
        difficultyTextWin.text = PlayerPrefs.GetString("difficultyText");
        PlayerPrefs.SetInt("maxWords", maxWords);
    }

}
