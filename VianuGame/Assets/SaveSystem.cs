using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    private void Awake()
    {
        foreach(GameObject objectG in gameObjects)
        {
            objectG.SetActive(true);
        }
    }
}
