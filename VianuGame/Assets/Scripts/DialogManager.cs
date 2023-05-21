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

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && manager.story.activeInHierarchy){
            DisplayNextSentence();
        }
    }
    private void DisplayNextSentence(){
        if(sentences.Count == 0)
        {
            audioSource.GetComponent<menuMusic>().active = true;
            manager.PlayGame();
            return;
        }
            string activeSentence = sentences.Dequeue();
            text.text = activeSentence;
    }
}