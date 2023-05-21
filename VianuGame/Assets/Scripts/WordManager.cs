using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public Text wordText;
    public int score = 0;
    public int maxWords = 0;
    public float imageSizeAdder = 0;
    public TextAsset wordFile;
    [SerializeField] Image imageFiller;
    [SerializeField] WinMenuManager winReq;

    [SerializeField] Text howMuchToCompletion;

    private string[] words;
    private string currentWord;
    private bool isWordCompleted = false;

    [SerializeField] AudioSource correctWord;

    private void Start()
    {
        correctWord = GameObject.Find("CorrectWord").GetComponent<AudioSource>();
        maxWords = PlayerPrefs.GetInt("maxWords");
        UpdateProgressionText();
        LoadWords();
        LoadRandomWord();
        imageSizeAdder = 1.0f / PlayerPrefs.GetInt("maxWords") * 1.0f;
        imageFiller.fillAmount = 0;
    }

    private void LoadWords()
    {
        if (wordFile != null)
        {
            words = wordFile.text.Split('\n');
        }
    }

    private void LoadRandomWord()
    {
        if (words != null && words.Length > 0)
        {
            currentWord = words[Random.Range(0, words.Length)].Trim();
            wordText.text = currentWord;
            isWordCompleted = false;
        }
    }

    private void Update()
    {
        if (!isWordCompleted && Input.anyKeyDown)
        {
            char firstLetter = currentWord[0];
            if (Input.GetKeyDown(firstLetter.ToString()))
            {
                currentWord = currentWord.Substring(1);
                wordText.text = currentWord;

                if (currentWord.Length == 0)
                {
                    isWordCompleted = true;
                    correctWord.Play();
                    score++;
                    NextWord();
                }
            }
        }
        winReq.OpenMenu();
        updateFillAmount();
        UpdateProgressionText();

    }

    private void NextWord()
    {
        LoadRandomWord();
    }
    void updateFillAmount()
    {
        if (imageFiller.fillAmount < imageSizeAdder * score)
        {
            imageFiller.fillAmount += Time.deltaTime * 1.5f;
        }
    }
    void UpdateProgressionText()
    {
        howMuchToCompletion.text = score + "/" + PlayerPrefs.GetInt("maxWords");
    }
}
