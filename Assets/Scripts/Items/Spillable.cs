using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class Spillable : MonoBehaviour
{
    /*
     * Класс-компонент отвечающий расссыпание(выливание).
    */

    [SerializeField] private ParticleSystem spillEffect;
    [SerializeField] private AudioSource spillAudio;
    
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private int maxParticles = 100;

    private ParticleSystem.EmissionModule emissionModule;

    private bool _isSpilling;
    private bool _useEffect;
    private Vector3 lastRotation;

    void Start()
    {
        _isSpilling = false;
        useEffect = true;
        lastRotation = transform.eulerAngles;
        
        if (spillEffect == null)
        {
            spillEffect = GetComponent<ParticleSystem>();
        }
        emissionModule = spillEffect.emission;
    }

    private void FixedUpdate()
    {
        AdjustEffect();
    }

    private void AdjustEffect()
    {
        if (!useEffect)
        {
            return;
        }
        
        if (isSpilling)
        {
            emissionModule.rateOverTime = maxParticles;
            if (!spillAudio.isPlaying) spillAudio.Play();
        }
        else
        {
            emissionModule.rateOverTime = 0;
            if (spillAudio.isPlaying) spillAudio.Stop();
        }
    }

    public bool isSpilling
    {
        get
        {
            if (lastRotation != transform.eulerAngles)
            {
                lastRotation = transform.eulerAngles;

                float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
                float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

                if (cosX * cosZ <= -0.1f)
                {
                    _isSpilling = true;
                }
                else
                {
                    _isSpilling = false;
                }
            }

            return _isSpilling;
        }
    }

    public bool useEffect
    {
        set
        {
            _useEffect = value;
        }
        
        get { return _useEffect; }
    }
}
