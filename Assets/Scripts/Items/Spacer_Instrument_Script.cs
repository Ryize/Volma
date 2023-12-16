using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spacer_Instrument_Script : PGP_Zone_Quest_Script
{
    /*
     * Класс распорки над дверным проёмом (при ПГП квесте)
    */

    private MeshRenderer meshRenderer;

    protected override void Start()
    {
        canBeSet = false;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log("[Spacer_Instrument_Script] target: " + other.name);
        
        // Объектом должна быть распорка
        if (!other.transform.parent.name.ToLower().Contains("spacer"))
        {
            return;
        }
        
        canBeSet = true;
    }

    protected override void OnTriggerExit(Collider other)
    {
        // Объектом должна быть распорка
        if (!other.transform.parent.name.ToLower().Contains("spacer"))
        {
            return;
        }
        
        canBeSet = false;

        other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        
        meshRenderer.enabled = true;
    }

    public override void SetPgp(GameObject obj)
    {
        if (canBeSet)
        {
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;

            meshRenderer.enabled = false;
            
            CompleteQuest();
        }
    }
}
