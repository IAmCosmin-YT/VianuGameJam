using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour
{

    public bool active = false;
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime * .5f;
        }
    }
}
