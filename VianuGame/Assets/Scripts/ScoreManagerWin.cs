using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerWin : MonoBehaviour
{
    [SerializeField] float time = 0f;
    [SerializeField] int score = 0;
    [SerializeField] int bestScore = 0;
    [SerializeField] Score wordScore;
    [SerializeField] Magician magician;

    [SerializeField] Text TimeText;
    [SerializeField] Text WordsText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text BestScoreText;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("maxWords") > wordScore.nr)
        {
            time += Time.deltaTime;
            score = magician.enemiesKilled;

            if (score > bestScore)
            {
                bestScore = score;
                UpdateBestScoreText();
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            WordsText.text = $"Words: {wordScore.nr+1}";

            UpdateTimeText();
            UpdateScoreText();
        }
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        TimeText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    private void UpdateBestScoreText()
    {
        BestScoreText.text = "Best Score: " + bestScore.ToString();
    }
}
