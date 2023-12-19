using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Spacer_Instrument_Script : PGP_Zone_Quest_Script
{
    /*
     * Класс распорки над дверным проёмом (при ПГП квесте)
    */

    /*protected override void Start()
    {
        canBeSet = false;
    }

    /*protected override void OnTriggerEnter(Collider other)
    {
        
        // Объектом должна быть распорка
        if (!other.transform.parent.name.ToLower().Contains("spacer"))
        {
            return;
        }
        
        canBeSet = true;
    }#1#

    protected override void OnTriggerExit(Collider other)
    {
        canBeSet = false;
    }

    public override void SetPgp(GameObject obj)
    {
        if (canBeSet)
        {
            obj.GetComponent<Rigidbody>().isKinematic = true;
            
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;

            obj.GetComponent<Interactable>().enabled = false;

            CompleteQuest();
            
            gameObject.SetActive(false);
        }
    }*/
}
