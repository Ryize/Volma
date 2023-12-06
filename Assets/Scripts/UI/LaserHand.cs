using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.HID;
using Valve.VR.Extras;

public class LaserHand : SteamVR_LaserPointer
{
    public override void OnPointerIn(PointerEventArgs e)
    {
        Debug.Log("[LaserHand] target: " + e.target.name);
        
        if(e.target.CompareTag("ButtonUI"))
        {
            Debug.Log("button");
            e.target.GetComponent<Image>().color=Color.cyan;
        }

        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI"))
        {
            Debug.Log("panel");
            pointer.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);
        
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        if(e.target.CompareTag("ButtonUI"))
        {
            Debug.Log("button");
            e.target.GetComponent<Image>().color=Color.white;
        }
        
        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI"))
        {
            Debug.Log("panel");
            pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
