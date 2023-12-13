using UnityEngine;

public class Primer_Resource_Script : MonoBehaviour
{
    public CounterTracker cuvetteFillAmount;
    public GameObject primerPaint;
    //звук выливания из канистры
    private AudioSource _bottleMovementSound;

    private void Start()
    {
        InvokeRepeating("Primer", 1f, 1f);
        _bottleMovementSound = GetComponent<AudioSource>();
    }

    void Primer() {
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        
        float distance = 1f;

        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, distance)) {

            float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
            float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

            if (cosX * cosZ <= 0)
            {
                // воспроизведение звука выливания из канистры
                _bottleMovementSound.Play();

                // Если объект не кюветка   
                if (!hit.transform.name.Contains("Cuvette"))
                {
                    return;
                }
            }
            else
            {
                _bottleMovementSound.Pause();
                cuvetteFillAmount.tracker += 0.5f;
            }

            if (cuvetteFillAmount.tracker > 1f)
                primerPaint.SetActive(true);
        }
    }
}
