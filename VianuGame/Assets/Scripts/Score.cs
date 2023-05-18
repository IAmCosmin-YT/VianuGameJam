using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Image image;
    [SerializeField] public int nr = 0;
    public int maxWords = 20;
    [SerializeField] private float imageSizeAdder;

    private void Start()
    {
        maxWords = 10 * PlayerPrefs.GetInt("difficulty");
        imageSizeAdder = 1.0f / maxWords * 1.0f;
        image.fillAmount = 0;
    }
    public void Increment()
    {
        nr++;
    }
    private void Update()
    {
        if (image.fillAmount < imageSizeAdder * nr)
        {
            image.fillAmount += Time.deltaTime * 1.5f;
        }
    }
    private void OnApplicationQuit()
    {
        int x = 10 * PlayerPrefs.GetInt("difficulty");
        PlayerPrefs.SetInt("maxWords", x);
        image.fillAmount = 0;
        nr = 0;
        imageSizeAdder = 0;

    }
}