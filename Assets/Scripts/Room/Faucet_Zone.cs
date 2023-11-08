using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Faucet_Zone : MonoBehaviour
{
    public GameObject handle;

    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.name.ToLower().Contains("bucket"))
        {
            return;
        }
        Debug.Log("handle angle: " + Mathf.Abs(Mathf.Sin(handle.transform.eulerAngles.y)));
        
        other.transform.parent.GetComponent<CounterTracker>().tracker 
            += (Mathf.Sin(handle.transform.eulerAngles.y)) * Time.deltaTime;
    }
}
