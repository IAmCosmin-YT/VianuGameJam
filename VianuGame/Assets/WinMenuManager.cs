using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuManager : MonoBehaviour
{

    [SerializeField] private Animator bgA;
    [SerializeField] private Animator menuA;
    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject zana;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject[] enemies;

    [SerializeField] Score Score;
    public void OpenMenu()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Score.nr == Score.maxWords)
        {
            manager.SetActive(false);
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            zana.SetActive(false);
            winMenu.SetActive(true);
            bgA.SetBool("menuOpen", true);
            menuA.SetBool("menuOpen", true);
        }
    }
}
