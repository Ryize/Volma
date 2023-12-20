using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.HID;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserHand : SteamVR_LaserPointer
{
    private Hand hand;
    
    public override void OnPointerIn(PointerEventArgs e)
    {
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color=Color.cyan;
        }

        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI") || e.target.tag.ToLower().Contains("item"))
        {
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

        if (e.target.tag.ToLower().Contains("item"))
        {
            e.target.position = transform.position;
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        if(e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color=Color.white;
        }
        
        if (e.target.CompareTag("Panel") || e.target.CompareTag("ButtonUI") || e.target.tag.ToLower().Contains("item"))
        {
            pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
