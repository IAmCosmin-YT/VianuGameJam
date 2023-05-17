using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Image image;
    [SerializeField] private int nr = 0;
    [SerializeField] private int maxWords = 20;
    [SerializeField] private float imageSizeAdder;

    private void Start() {
        imageSizeAdder = image.fillAmount / maxWords * 1.0f;
        image.fillAmount = 0;
    }
    public void Increment(){
        nr++;
    }
    private void Update()
    {
        if(image.fillAmount < imageSizeAdder * nr)
        {
            image.fillAmount += Time.deltaTime * 1.5f;
        }
    }
}
