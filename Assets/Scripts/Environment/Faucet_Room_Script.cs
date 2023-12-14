using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Faucet_Room_Script : Base
{
    /*
     * Скрипт для набирания воды в ведро
     *
     * При набирании воды выключает пустое ведро, и включает ведро с водой
    */
    
    // Сколько осталось набрать воды
    //private float bucketCounter;
    
    //private ParticleSystem.Trails waterTrails;

    public GameObject stats;

    private void Start()
    {
        InvokeRepeating("FaucetWork", 1f, 1f);
    }

    /*
     * Метод набирания воды в ведро
     *
     * Набрает воду в ведро
     */
    private void FaucetWork()
    {
        // напор крана
        float faucetHandleAngle = transform.GetChild(3).localRotation.eulerAngles.y;
        float faucetForce = Mathf.Abs(Mathf.Sin(faucetHandleAngle) * 0.5f);

        stats.GetComponent<Stats>().water += faucetForce;
        
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;
        Debug.Log("[Faucet_Room_Script] FaucetWork derection: " + derection);

        // Максимальная дистанция для засыпания
        float distance = 3f;

        RaycastHit bucket;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out bucket, distance))
        {
            return;
        }
        Debug.Log("[Faucet_Room_Script] FaucetWork bucket: " + bucket.transform.name);
        
        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket"))
        {
            return;
        }
        
        GameObject empty = bucket.transform.GetChild(bucket.transform.childCount - 1).gameObject;
        
        // Если поставлено не пустое ведро
        if (!empty.activeSelf)
        {
            return;
        }
        
        Debug.Log("[Faucet_Room_Script] FaucetWork empty: " + empty.name);

        // получаем трекер количества воды в ведре
        
        bucket.transform.GetComponent<CounterTracker>().tracker += faucetForce;
        float bucketCounter = bucket.transform.GetComponent<CounterTracker>().tracker;
        /*
         * 
        float bucketCounter = bucket.transform.GetComponent<CounterTracker>().Get();
        bucket.transform.GetComponent<CounterTracker>().Add(faucetForce);
         */
        
        Debug.Log("[Faucet_Room_Script] FaucetWork FaucetHandleY: " + faucetHandleAngle);
        Debug.Log("[Faucet_Room_Script] FaucetWork FaucetHandleYsin: " + faucetForce);
        Debug.Log("[Faucet_Room_Script] FaucetWork bucketCounter: " + bucket);
        
        // Если ведро заполнено
        if (bucketCounter > 6)
        {
            bucket.transform.GetChild(1).gameObject.SetActive(true);
            empty.SetActive(false);
            bucket.transform.GetComponent<CounterTracker>().tracker = 0f;
        }
    }
    
    void Notify(string type, bool status)
    {
        /*
         * Метод уведомления о событии
         *
         * Отслеживается событие bucketInArea.
         * И в зависимости от успешности проверок ведро набирается 
        */
    }
}
