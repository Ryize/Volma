using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Faucet_Room_Script : Base
{
    /*
     * Скрипт для набирания воды в ведро
     *
     * При набирании воды выключает пустое ведро, и включает ведро с водой
    */

    [SerializeField] private Transform faucetHandleTransform;

    [Header("Water Leak")] 
    [SerializeField]
    private Transform waterLeakTransform;
    // Эффекты воды
    [SerializeField]
    private ParticleSystem waterParticles;
    [SerializeField]
    private ParticleSystem waterSplashParticles;
    
    // Звук воды
    [SerializeField]
    private AudioSource waterAudioSource;

    [SerializeField] private float litersPerSecond = 0.5f;

    [SerializeField] private Stats stats;

    private Vector3 lastRotation;
    private float faucetForce;
    
    private Bucket_Item_Script cachedBucket = null;

    private void Start()
    {
        waterParticles.maxParticles = 0;
        waterSplashParticles.maxParticles = 0;

        lastRotation = faucetHandleTransform.eulerAngles;
    }

    private void Update()
    {
        FaucetWork();
    }
    
    private Bucket_Item_Script BucketRaycast()
    {
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;

        // Максимальная дистанция для засыпания
        float distance = 10f;

        RaycastHit bucket;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out bucket, distance))
        {
            return null;
        }

        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("water"))
        {
            return null;
        }
        
        if (cachedBucket && cachedBucket.transform == bucket.transform)
            return cachedBucket;

        return bucket.transform.GetComponent<Bucket_Item_Script>();
    }

    // напор крана
    private void CalculateForce()
    {
        if (faucetHandleTransform.eulerAngles != lastRotation)
        {
            lastRotation = faucetHandleTransform.eulerAngles;
            float faucetHandleAngle = faucetHandleTransform.localRotation.eulerAngles.y;
            faucetForce = Mathf.Abs(Mathf.Sin(faucetHandleAngle)) * litersPerSecond;
            
            ChangeEffect();
        }
    }

    private void ChangeEffect()
    {
        waterParticles.maxParticles = (int) (faucetForce * 10);
        waterSplashParticles.maxParticles = (int) (faucetForce * 10);
    }

    private void ChangeSound()
    {
        
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
            waterAudioSource.volume = faucetForce * litersPerSecond;
        }
    }
    
    private void FaucetWork()
    {
        CalculateForce();
        ChangeSound();
        
        if (faucetForce < 0.01f)
            return;

        cachedBucket = BucketRaycast();

        // Добавление расхода воды в статистику
        stats.water += faucetForce * Time.deltaTime;
        
        if (cachedBucket)
        {
            cachedBucket.waterVolume += faucetForce * Time.deltaTime;
        }
    }
}
