using UnityEngine;
using System.Collections.Generic;

public class PGP_Quest_Script : Quest
{
    // Счетчик ПГП
    private int pgpCounter;

    // Менеджер объектов
    public Item_Manager manager;

    // Тип событий, который отслеживается 
    public List<string> subTypes;
    
    private void Start()
    {
        pgpCounter = 0;
        
        foreach (var type in subTypes)
        {
            manager.Subscribe(type, this);
        }
    }
    
    public override void Notify(string questType)
    {
        switch (questType)
        {
            case "bucket_completed":
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "pgp_zone_completed":
                NextPgpZone();
                break;
        }
    }

    private void NextPgpZone()
    {
        if (transform.childCount > pgpCounter+1)
        {
            transform.GetChild(++pgpCounter).gameObject.SetActive(true);
        }
        else
        {
            manager.Notify_PGP_Quest();
        }
    }

    public void SetPpg(GameObject obj)
    {
        transform.GetChild(pgpCounter).GetComponent<PGP_Zone_Quest_Script>().SetPgp(obj);
    }
}
