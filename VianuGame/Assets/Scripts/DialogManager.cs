using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    [SerializeField] private StartManager manager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text text;

    private void Start() {
        audioSource = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<AudioSource>();
        audioSource.volume = 1;
        manager = GetComponent<StartManager>();
        sentences = new Queue<string>();
    }

    public void Story(string[] _sentences){
        sentences.Clear();
        foreach(string sent in _sentences){
            sentences.Enqueue(sent);
        }
        text.text = sentences.Peek();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0)
        {
            audioSource.GetComponent<menuMusic>().active = true;
            manager.PlayGame();
            return;
        }
        Debug.Log("DisplayNextSentence called");
        string activeSentence = sentences.Dequeue();
        text.text = activeSentence;
    }
}