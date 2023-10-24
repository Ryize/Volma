using System.Collections;
using UnityEngine;

public class Pallet_Instrumnet_Script : MonoBehaviour
{
    //public EventZone_Script counter;
    public Rigidbody shpatel;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag.ToLower().Contains("task") || other.tag.ToLower().Contains("basket")))
            return;
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();

        Debug.Log("Shpatel: " + meshRenderer.enabled + " name: " + otherName);
        // Если на шпателе есть клей
        if (!meshRenderer.enabled) {
            Debug.Log("shpatel1");
            // Если объект ведро, жижа замешена и на шпателе нет клея
            if (otherName.Contains("basket") && 
            other.transform.parent.GetChild(3).gameObject.activeSelf) {
                meshRenderer.enabled = true;
                Debug.Log("shpatel2");
            }
        }
        // else {
        //     // Если объект event
        //     if (otherName.Contains("horizontalzone") || otherName.Contains("verticalzone")) {
        //         Debug.Log("shpatel3");
        //         EventZone_Script counter = other.transform.gameObject.GetComponent<EventZone_Script>();
        //         counter.EventZoneCounter -= shpatel.velocity.magnitude;

        //         if (counter.EventZoneCounter < 0.1) {
        //             Destroy(other.transform.gameObject);
        //             meshRenderer.enabled = false;
        //         }
        //     }
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.ToLower().Contains("task"))
            return;
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
        Transform eventZone = other.transform.parent;

        // Если объект event
        if (meshRenderer.enabled && 
        (otherName.Contains("horizontalzone") || otherName.Contains("verticalzone"))) {
            Destroy(other.transform.gameObject);
            meshRenderer.enabled = false;
        }

        // Если пгп не активна
        if (!eventZone.GetChild(0).gameObject.activeSelf)
            return;

        if (otherName.Contains("horizontalglue") || otherName.Contains("verticalglue")) {
            Destroy(other.transform.gameObject);
        }
        
        /*if (eventZone.childCount <= 2)
            eventZone.GetComponent<PGP_Event_Zone>().CompleteQuest();*/
    }
}
