using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private Word activeWord;
    public Text text, progress;
    public Score score;
    public soundManager soundManager;
    public AudioClip sound;
    public WinMenuManager winMenuManager;
    private bool hasActiveWord;
    private int increment = 0;

    private void Start() {
        AddWord();
        progress.text = increment + "/" + score.maxWords;
    }
    public void AddWord(){
        Word word = new Word(WordGenerator.GetRandomWord(), text);
        words.Add(word);
    }

    public void TypeLetter(char letter){
        if(hasActiveWord){
            if(activeWord.GetNextLetter() == letter){
                activeWord.TypeLetter();
            }
            if(activeWord.WordTyped()){
                AddWord();
                score.Increment();
                progress.text = ++increment + "/" + score.maxWords;
                soundManager.source.pitch = 1;
                soundManager.PlaySound(sound);
            }
        }
        else{
            foreach(Word word in words){
                if(word.GetNextLetter() == letter){
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if(hasActiveWord && activeWord.WordTyped()){
            hasActiveWord = false;
            words.Remove(activeWord);
            if(score.maxWords == increment){
                winMenuManager.OpenMenu();
            }
        }
    }
}
