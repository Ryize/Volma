using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Script : MonoBehaviour
{
    public float dirtCounter = 1000f;

    void Update()
    {
        if (dirtCounter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
