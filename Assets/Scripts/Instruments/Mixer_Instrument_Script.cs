using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mixer_Instrument_Script : MonoBehaviour
{
    public GameObject mixerAuger;
    public float bucketMixing = 10;
    public GameObject pgpEvents;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider name: " + other.transform.name);
        
        // Если не миксер
        if (other.transform.parent.GameObject() != mixerAuger)
            return;
        
        float speed = mixerAuger.GetComponent<Mixer_Animation_Instrument_Script>().GetSpeed();

        bucketMixing -= speed;

        if (bucketMixing < 0.1)
        {
            transform.parent.GetChild(3).gameObject.SetActive(true);
            transform.GameObject().SetActive(false);
            pgpEvents.SetActive(true);
        }
    }
}
