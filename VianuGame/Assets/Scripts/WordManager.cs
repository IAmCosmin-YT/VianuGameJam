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
<<<<<<< HEAD
    [SerializeField] Magician magician;
    //public WordSpawner wordSpawner;
<<<<<<< Updated upstream
    private bool hasActiveWord; 
=======
=======
    public soundManager soundManager;
    public AudioClip sound;
>>>>>>> 19a5b185a4d33ec07b56ef0ee6daa1751ab67042
    private bool hasActiveWord;
    private int increment = 0;
>>>>>>> Stashed changes

    private void Start() {
        magician = GameObject.Find("Mage").GetComponent<Magician>();
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
                magician.Heal();
                AddWord();
                score.Increment();
<<<<<<< Updated upstream
=======
                progress.text = ++increment + "/" + score.maxWords;
                soundManager.source.pitch = 1;
                soundManager.PlaySound(sound);
>>>>>>> Stashed changes
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
