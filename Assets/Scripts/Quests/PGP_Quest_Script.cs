using UnityEngine;
using System.Collections.Generic;

public class PGP_Quest_Script : Quest
{
    // ������� ���
    private int pgpCounter;

    // �������� ��������
    public Item_Manager manager;

    // ��� �������, ������� ������������� 
    public List<string> subTypes;
    
    private void Start()
    {
        pgpCounter = 0;
        
        foreach (var type in subTypes)
        {
            manager.subscribe(type, this);
        }
    }
    
    public override void Notify(string questType, bool status)
    {
        NextPgpZone();
    }

    private void NextPgpZone()
    {
        if (transform.childCount > pgpCounter+1)
        {
            transform.GetChild(++pgpCounter).gameObject.SetActive(true);
        }
    }

    public void SetPpg()
    {
        transform.GetChild(pgpCounter).GetComponent<PGP_Zone_Quest_Script>().SetPgp();
    }
}
