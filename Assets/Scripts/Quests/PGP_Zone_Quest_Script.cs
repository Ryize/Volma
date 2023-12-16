using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PGP_Zone_Quest_Script : MonoBehaviour
{
    private bool questStatus;
    private Vector3 standardPgpZone;
    private GameObject PGP;
    private GameObject originalPGP;
    private GameObject PgpZone;
    private bool canBeSet;
    
    private void Start()
    {
        questStatus = false;
        standardPgpZone = new Vector3(-2.31900001f, 0.254000306f, 1.29499996f);
        PGP = transform.GetChild(0).gameObject;
        PgpZone = transform.GetChild(5).gameObject;
        canBeSet = false;
    }

    public void CompleteQuest()
    {
        questStatus = true;
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    public bool GetQuestStatus()
    {
        return questStatus;
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
