using UnityEngine;

public class Primer_Resource_Script : MonoBehaviour
{
    private CounterTracker cuvetteFillAmount;

    public GameObject primerQuest;
    
    //звук выливания из канистры
    private AudioSource _bottleMovementSound;

    private void Start()
    {
        InvokeRepeating("Primer", 1f, 1f);
        _bottleMovementSound = GetComponent<AudioSource>();
    }

    void Primer() {
        float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

        if (cosX * cosZ <= 0)
        {
            // воспроизведение звука выливания из канистры
            _bottleMovementSound.Play();
        }
        else
        {
            _bottleMovementSound.Pause();
            return;
        }
        
        
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        
        float distance = 1f;
        RaycastHit hit;

        if (!Physics.Raycast(origin, direction, out hit, distance)) {
            return;
        }
    
        // Если объект не кюветка   
        if (!hit.transform.name.ToLower().Contains("cuvette"))
        {
            return;
        }

        Transform cuvette = hit.transform;

        cuvetteFillAmount = cuvette.GetComponent<CounterTracker>();

        if ((cuvetteFillAmount.tracker += 0.1f) >= 0.5f)
        {
            cuvette.GetChild(1).gameObject.SetActive(true);
            primerQuest.SetActive(true);
        }
    }
}
