using UnityEngine;

public class Kran_Script : MonoBehaviour
{
    public Bucket_In_Area bucketInArea;
    public GameObject bucket;
    public float bucketFillAmount;
    public ParticleSystem water;

    private void Start()
    {
        InvokeRepeating("RotatedKran", 1f, 1f);
    }

    void RotatedKran ()
    {
        var waterTrails = water.trails;
        waterTrails.ratio = Mathf.Sin(transform.eulerAngles.y);
        
        // Если ведро не в зоне
        if (!bucketInArea)
            return;

        GameObject empty = bucket.transform.GetChild(bucket.transform.childCount - 1).gameObject;
        
        // Если поставлено не пустое ведро
        if (!empty.activeSelf)
            return;
        
        // сила напора
        bucketFillAmount -= Mathf.Sin(transform.eulerAngles.y);
        
        // Если ведро заполнено
        if (bucketFillAmount < 0.1)
        {
            bucket.transform.GetChild(1).gameObject.SetActive(true);
            empty.SetActive(false);
        }
    }
}
