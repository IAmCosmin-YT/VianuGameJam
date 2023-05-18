using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorSetSpeedRandom : MonoBehaviour
{

    [SerializeField]Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.speed = Random.Range(0.5f, 1f);
    }
}
