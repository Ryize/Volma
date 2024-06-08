using UnityEngine;
using Valve.VR.InteractionSystem;

public class PGP_Zone_Quest_Script : MonoBehaviour
{
    [SerializeField]
    private PositionKeeper standardPgpZone;
    private GameObject PgpZone;
    private bool pgpIsSetted;
    
    public Item_Repository repository;

    private GameObject PGP;

    private GameObject glueH, glueV;

    protected virtual void Start()
    {
        PGP = transform.GetChild(0).gameObject;
        glueV = transform.GetChild(3).gameObject;
        glueH = transform.GetChild(4).gameObject;
        PgpZone = transform.GetChild(5).gameObject;
        pgpIsSetted = false;
    }

    public void CompleteQuest()
    {
        repository.PGPAmount--;
        
        Debug.Log("[PGP_Zone_Quest_Script] zone: " + transform.name + " complete");
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        Debug.Log("[PGP_Zone_Quest_Script] collider: " + other.name);

        if (pgpIsSetted)
        {
            return;
        }
        
        // Должно быть три ребенка (пгп, вертикальный и горизонтальный клей)
        if (!(glueV.activeSelf && glueH.activeSelf))
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

        if (!other.transform.parent.GetComponent<Interactable>().attachedToHand)
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
        PGP.SetActive(true);

        standardPgpZone.TpToDefaultPosition();

        pgpIsSetted = true;
    }
}
