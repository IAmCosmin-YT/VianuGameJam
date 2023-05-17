using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList;
    public static string GetRandomWord(){
        wordList = System.IO.File.ReadAllLines("Assets/Words.txt");
        int randIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randIndex];
        return randomWord;
    }
}
