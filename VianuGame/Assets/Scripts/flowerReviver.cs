using UnityEngine;
using UnityEngine.UI;

public class flowerReviver : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] flowers;
    [SerializeField] Image tree;
    [SerializeField] WordManager score;
    [SerializeField] Camera cameraSkybox;
    [SerializeField] Gradient colorGradient;
    [SerializeField] Gradient colorGradient2;
    [SerializeField] Gradient colorGradient3;


    private void Update()
    {
        int currentScore = score.score;
        float percentage = Mathf.Clamp01(currentScore / (float)PlayerPrefs.GetInt("maxWords"));
        Color targetColor = colorGradient.Evaluate(percentage);
        Color targetColor2 = colorGradient2.Evaluate(percentage);
        Color targetColor3 = colorGradient3.Evaluate(percentage);

        foreach (SpriteRenderer flower in flowers)
        {
            flower.color = targetColor;
        }
        cameraSkybox.backgroundColor = targetColor2;
        tree.color = targetColor3;
    }
}
