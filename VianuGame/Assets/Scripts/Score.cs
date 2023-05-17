using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private int maxWords = 20;

    private void Start() {
        slider.maxValue = maxWords;
    }
    public void Increment(){
        slider.value += 1;
    }
}
