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
    public TextAsset wordFilePhone;
    [SerializeField] Image imageFiller;
    [SerializeField] WinMenuManager winReq;
    [SerializeField] Magician magician;
    RuntimePlatform currentPlatform;
    [SerializeField] Text howMuchToCompletion;
    [SerializeField] LetterFall letterFall;

    private string[] words;
    [HideInInspector] public string currentWord;
    private bool isWordCompleted = false;

    [SerializeField] AudioSource correctWord;

    private void Start()
    {
        currentPlatform = PlatformDetector.platform;
        correctWord = GameObject.Find("CorrectWord").GetComponent<AudioSource>();
        maxWords = PlayerPrefs.GetInt("maxWords");
        UpdateProgressionText();
        LoadWords();
        LoadRandomWord();
        imageSizeAdder = 1.0f / PlayerPrefs.GetInt("maxWords") * 1.0f;
        imageFiller.fillAmount = 0;
        howMuchToCompletion.text = $"{score}/{maxWords}";
    }

    private void LoadWords()
    {
        if (wordFile != null && (currentPlatform != RuntimePlatform.Android || currentPlatform != RuntimePlatform.IPhonePlayer))
        {
            words = wordFile.text.Split('\n');
        }
        else if (wordFilePhone != null && (currentPlatform == RuntimePlatform.Android || currentPlatform == RuntimePlatform.IPhonePlayer))
        {
            words = wordFilePhone.text.Split('\n');
        }
    }

    private void LoadRandomWord()
    {
        if (words != null && words.Length > 0)
        {
            currentWord = words[Random.Range(0, words.Length)].Trim();
            wordText.text = currentWord;
            isWordCompleted = false;
            letterFall.getCharFromWord(currentWord);
        }
    }

    private void Update()
    {
        subtractLetter();
        winReq.OpenMenu();
        updateFillAmount();
        UpdateProgressionText();

    }

    public void subtractLetter()
    {
        if (!isWordCompleted && Input.anyKeyDown && Time.timeScale != 0)
        {
            char firstLetter = currentWord[0];
            if (Input.GetKeyDown(firstLetter.ToString()))
            {
                currentWord = currentWord.Substring(1);
                wordText.text = currentWord;

                if (currentWord.Length == 0)
                {
                    isWordCompleted = true;
                    magician.Heal();
                    correctWord.Play();
                    score++;
                    NextWord();
                }
            }
        }
    }

    public void subtractSameLetters(char input)
    {
        string newWord = "";

        foreach (char letter in currentWord)
        {
            if (letter != input)
            {
                Debug.Log(newWord);
                newWord += letter;
            }
        }

        currentWord = newWord;
        wordText.text = currentWord;

        if (currentWord.Length == 0)
        {
            isWordCompleted = true;
            magician.Heal();
            correctWord.Play();
            score++;
            NextWord();
        }
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
