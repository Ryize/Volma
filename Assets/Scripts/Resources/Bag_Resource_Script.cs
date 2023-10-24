using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    public float bucketFillAmount;
    public GameObject bucket;

    private void Start()
    {
        InvokeRepeating("Primer", 1f, 1f);
    }

    void Primer() {
        if (!bucket.transform.GetChild(1).gameObject.activeSelf)
            return;
        
        Debug.Log("Bucket has water");
        
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;
        
        float distance = 10f;

        RaycastHit hit;

        if (Physics.Raycast(origin, derection, out hit, distance)) {
            // Если объект не ведро
            Debug.Log("hit object: " + hit.transform.name);
            
            if (!hit.transform.name.Contains("bucketVR")) {
                return;
            }
            
            Debug.Log("Bucket hit");

            float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
            float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            
            if (cosX * cosZ <= 0) {
                bucketFillAmount -= transform.GetComponent<Rigidbody>().velocity.magnitude;
            }

            if (bucketFillAmount < 0.1)
            {
                bucket.transform.GetChild(2).gameObject.SetActive(true);
                bucket.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
