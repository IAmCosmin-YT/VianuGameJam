using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private void Awake()
    {
        if(PlayerPrefs.GetInt("difficulty") == 0)
        {
            PlayerPrefs.SetInt("difficulty", 2);
        }
        if (PlayerPrefs.GetInt("maxWords") == 0)
        {
            PlayerPrefs.SetInt("maxWords", 20);
        }
    }
}
