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
    
    private void Start()
    {
        standardPgpZone = new Vector3(-2.31900001f, 0.254000306f, 1.29499996f);
        PGP = transform.GetChild(0).gameObject;
        PgpZone = transform.GetChild(5).gameObject;
        canBeSet = false;
    }

    public void CompleteQuest()
    {
        manager.Notify_PGP_Zone_Quest(true);
        
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ ���� ��� ������� (���, ������������ � �������������� ����)
        if (transform.childCount != 4)
        {
            return;
        }
        
        // �������� ������ ���� ���
        if (!other.name.ToLower().Contains("pgp"))
        {
            return;
        }
        
        // ���������� �������� ���
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
        // ������ ���� ��� ������� (���, ������������ � �������������� ����)
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
