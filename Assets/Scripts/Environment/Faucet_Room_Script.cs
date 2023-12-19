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
    private CounterTracker bucketCounter;
    
    // Эффекты воды
    private ParticleSystem waterParticles;
    private ParticleSystem waterSplashParticles;
    
    // Звук воды
    private AudioSource waterAudioSource;

    [SerializeField] private Stats stats;
    

    private void Start()
    {
        InvokeRepeating("FaucetWork", 1f, 1f);

        waterParticles = transform.GetChild(2).GetComponent<ParticleSystem>();
        waterSplashParticles = transform.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();

        waterParticles.maxParticles = 0;
        waterSplashParticles.maxParticles = 0;

        waterAudioSource = GetComponent<AudioSource>();
    }

    /*
     * Метод набирания воды в ведро
     *
     * Набрает воду в ведро
     */
    private void FaucetWork()
    {
        // напор крана
        float faucetHandleAngle = transform.GetChild(1).localRotation.eulerAngles.y;
        float faucetForce = Mathf.Abs(Mathf.Sin(faucetHandleAngle));

        waterParticles.maxParticles = (int) (faucetForce * 10);
        waterSplashParticles.maxParticles = (int) (faucetForce * 10);

        if (Mathf.Approximately(faucetForce, 0))
        {
            if (waterAudioSource.isPlaying)
            {
                waterAudioSource.Stop();
            }
        }
        else
        {
            if (!waterAudioSource.isPlaying)
            {
                waterAudioSource.Play();
            }
            waterAudioSource.volume = faucetForce * 0.5f;
        }
        
        stats.water += faucetForce * 0.5f;
        
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
        
        bucketCounter = bucket.transform.GetComponent<CounterTracker>();
        bucketCounter.tracker += faucetForce;
        /*
         * 
        float bucketCounter = bucket.transform.GetComponent<CounterTracker>().Get();
        bucket.transform.GetComponent<CounterTracker>().Add(faucetForce);
         */
        
        Debug.Log("[Faucet_Room_Script] FaucetWork FaucetHandleY: " + faucetHandleAngle);
        Debug.Log("[Faucet_Room_Script] FaucetWork FaucetHandleYsin: " + faucetForce);
        Debug.Log("[Faucet_Room_Script] FaucetWork bucketCounter: " + bucket);
        
        // Если ведро заполнено
        if (bucketCounter.tracker > 12)
        {
            bucket.transform.GetChild(1).gameObject.SetActive(true);
            empty.SetActive(false);
            bucketCounter.tracker = 0f;
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
