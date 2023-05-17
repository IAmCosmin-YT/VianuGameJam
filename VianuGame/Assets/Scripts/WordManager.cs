using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private Word activeWord;
    public Text text;
    public Score score;
    //public WordSpawner wordSpawner;
    private bool hasActiveWord; 

    private void Start() {
        AddWord();
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
        }
    }
}
