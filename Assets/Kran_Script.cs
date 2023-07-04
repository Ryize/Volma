using UnityEngine;

public class Kran_Script : MonoBehaviour
{
    public Bucket_In_Area bucketInArea;
    public GameObject bucket;
    public float bucketFillAmount;
    public ParticleSystem water;
    //private ParticleSystem.Trails waterTrails;
    
    private void Update() {
        RotatedKran();
    }

    void RotatedKran ()
    {
        /*// напор воды
        var trailsData = new ParticleSystem.Trails(true);
        trailsData.
        waterTrails.ratio = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad); 
        //water.emission = _emissionModule;
        water.SetEmissionRateOverTime(_emissionModule.rateOverTime);
        //water.SetEmissionRateOverTime(_emissionModule)
        water.set*/
        
        // Если ведро не в зоне
        if (!bucketInArea.isInArea)
            return;

        GameObject empty = bucket.transform.GetChild(bucket.transform.childCount - 1).gameObject;
        
        // Если поставлено не пустое ведро
        if (!empty.activeSelf)
            return;
        
        // сила напора
        bucketFillAmount -= Mathf.Sin(transform.eulerAngles.y) * Time.deltaTime;
        
        // Если ведро заполнено
        if (bucketFillAmount < 0.1)
        {
            bucket.transform.GetChild(1).gameObject.SetActive(true);
            empty.SetActive(false);
        }
    }
}
