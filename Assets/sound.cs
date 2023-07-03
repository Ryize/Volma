using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("faucet").GetComponent<bucketQuest>().isOpen)
        {
            GameObject.FindGameObjectWithTag("effect").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("effect").GetComponent<AudioSource>().mute = true;
        }

    }
}
