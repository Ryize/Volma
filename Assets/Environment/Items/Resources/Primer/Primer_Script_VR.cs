using UnityEngine;

public class Primer_Script_VR : MonoBehaviour
{
    public CuvetteFillAmount cuvetteFillAmount;
    public GameObject primerPaint;

    private void Start()
    {
        InvokeRepeating("Primer", 1f, 1f);
    }

    void Primer() {
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;
        
        float distance = 1f;

        float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        Debug.Log(cosX * cosZ);

        RaycastHit hit;

        if (Physics.Raycast(origin, derection, out hit, distance)) {
            // Если объект не кюветка   
            //Debug.Log("1");
            if (!hit.transform.name.Contains("CuvetteVR"))
                return;

            
            //Debug.Log("2");
            // float cosX = Mathf.Cos(hit.transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
            // float cosZ = Mathf.Cos(hit.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            // float cosX = Mathf.Cos(transform.rotation.eulerAngles.x);
            // float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z);
            // Debug.Log(cosX * cosZ);

            if (cosX * cosZ <= 0) {
                //Debug.Log("3");
                cuvetteFillAmount.cuvetteFillAmount -= 1;
            }

            if (cuvetteFillAmount.cuvetteFillAmount < 0.1)
                primerPaint.SetActive(true);
        }
    }
}
