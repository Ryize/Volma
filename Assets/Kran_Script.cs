using System;
using UnityEngine;

public class Kran_Script : MonoBehaviour
{
    public Bucket_In_Area bucketInArea;
    public GameObject bucketNoWater;
    public GameObject bucketWithWater;
    public double bucketFillAmount;
    private void Start()
    {
        InvokeRepeating("RotatedKran", 1f, 1f);
    }


    void Update()
    {
        //RotatedKran();
    }

    void RotatedKran ()
    {
        // Если ведро не в зоне
        if (!bucketInArea)
            return;

        // Если поставлено не пустое ведро
        if (!bucketNoWater.activeSelf)
            return;

        // сила напора
        bucketFillAmount -= Mathf.Sin(transform.eulerAngles.y);

        // Если ведро заполнено
        if (bucketFillAmount < 0.1)
        {
            bucketNoWater.SetActive(false);
            bucketWithWater.SetActive(true);
        }
    }
}
