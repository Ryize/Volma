using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PGP_Zone_Quest_Script : MonoBehaviour
{
    private Vector3 standardPgpZone;
    private GameObject PgpZone;
    private bool pgpIsSetted;
    
    public Item_Repository repository;

    [SerializeField] private GameObject PGP;
    
    protected virtual void Start()
    {
        standardPgpZone = new Vector3(-2.31900001f, 0.254000306f, 1.29499996f);
        PGP = transform.GetChild(0).gameObject;
        PgpZone = transform.GetChild(4).gameObject;
        pgpIsSetted = false;
    }

    public void CompleteQuest()
    {
        repository.PGPAmount--;
        
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (pgpIsSetted)
        {
            return;
        }
        
        // Должно быть три ребенка (пгп, вертикальный и горизонтальный клей)
        if (transform.childCount != 3)
        {
            return;
        }
        
        // Объектом должна быть пгп
        if (!other.name.ToLower().Contains("pgp_item"))
        {
            return;
        }
        
        // Активирует проекцию ПГП
        PgpZone.SetActive(true);

        if (!other.GetComponent<Interactable>().attachedToHand)
        {
            SetPgp(other.gameObject);
            PgpZone.SetActive(false);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        PgpZone.SetActive(false);
    }

    public virtual void SetPgp(GameObject obj)
    {
        var pgpName = obj.name.ToLower();
        
        if (pgpName.Contains("trash"))
        {
            return;
        }
        
        Debug.Log("[SetPGP] 3");

        Vector3 pgpPosition;

        if (pgpName.Contains("right"))
        {
            pgpPosition = new Vector3(-0.025f, 0.25f, -0.005f);
        }
        else
        {
            pgpPosition = new Vector3(-0.025f, 0.25f, -0.3335f);
        }
        
        
        Debug.Log("[SetPGP] 4");
        
        var newPGP = Instantiate(PGP);
        newPGP.name = "pgp_item";
        newPGP.transform.position = standardPgpZone;
        newPGP.transform.eulerAngles = new Vector3(-90, 0, 0);

        obj.name = "PGP_wall";
        obj.transform.SetParent(transform);
        obj.transform.localPosition = pgpPosition;
        obj.transform.eulerAngles = new Vector3(-90, 0, 0);
        Destroy(obj.GetComponent<Throwable>());
        Destroy(obj.GetComponent<Interactable>());
        Destroy(obj.GetComponent<Rigidbody>());
        Destroy(obj.GetComponent<CounterTracker>());
        
        if (obj.transform.childCount != 0)
        {
            Destroy(obj.transform.GetChild(0).gameObject);
        }

        pgpIsSetted = true;
    }
}
