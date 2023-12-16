using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PGP_Zone_Quest_Script : MonoBehaviour
{
    private Vector3 standardPgpZone;
    private GameObject PGP;
    private GameObject originalPGP;
    private GameObject PgpZone;
    private bool canBeSet;
    
    public Item_Manager manager;
    public Item_Repository repository;
    
    private void Start()
    {
        standardPgpZone = new Vector3(-2.31900001f, 0.254000306f, 1.29499996f);
        PGP = transform.GetChild(0).gameObject;
        PgpZone = transform.GetChild(5).gameObject;
        canBeSet = false;
    }

    public void CompleteQuest()
    {
        repository.PGP_Zone_Quest_isComplete = true;
        
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Должно быть три ребенка (пгп, вертикальный и горизонтальный клей)
        if (transform.childCount != 4)
        {
            return;
        }
        
        // Объектом должна быть пгп
        if (!other.name.ToLower().Contains("pgp"))
        {
            return;
        }
        
        // Активирует проекцию ПГП
        PgpZone.SetActive(true);

        canBeSet = true;
        originalPGP = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        PgpZone.SetActive(false);

        canBeSet = false;
    }

    public void SetPgp()
    {
        // Должно быть три ребенка (пгп, вертикальный и горизонтальный клей)
        if (transform.childCount != 4)
        {
            return;
        }

        if (canBeSet)
        {
            PGP.SetActive(true);
            originalPGP.transform.position = standardPgpZone;
        }
    }
}
