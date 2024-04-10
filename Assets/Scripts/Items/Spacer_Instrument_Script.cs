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

    public bool enableToSet;

    protected override void Start()
    {
        enableToSet = false;
    }

    protected override void OnTriggerStay(Collider other)
    {
        // Объектом должна быть распорка
        if (!other.transform.parent.name.ToLower().Contains("spacer"))
        {
            return;
        }

        if (!other.transform.parent.GetComponent<Interactable>().attachedToHand)
        {
            SetPgp(other.transform.parent.gameObject);
        }
    }

    public override void SetPgp(GameObject obj)
    {
        if (!enableToSet)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        Destroy(obj.GetComponent<Throwable>());
        Destroy(obj.GetComponent<Interactable>());
        Destroy(obj.GetComponent<Rigidbody>());
        
        CompleteQuest();
        
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        enableToSet = true;
    }
}
