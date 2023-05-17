using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Word
{
    private Text display;
    public string word;
    private int typeIndex;
    
    public Word(string _word, Text _display){
        word = _word;
        display = _display;
        typeIndex = 0;

        display.text = word;
    }

    public char GetNextLetter(){
        return word[typeIndex];
    }
    public void TypeLetter(){
        typeIndex++;
        display.text = display.text.Remove(0,1);
    }
    public bool WordTyped(){
        bool wordTyped = (typeIndex >= word.Length);
        return wordTyped;
    }
}
