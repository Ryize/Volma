using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Bucket_Item_Script : MonoBehaviour
{
    
    [Header("Spilling")]
    [SerializeField] private Spillable spillable;
    [SerializeField] AudioSource spillingAudio;

    [Header("Bucket volume")]
    [SerializeField] private float maxVolume = 20;

    [SerializeField] private float _waterVolume = 0;

    [SerializeField] private float _sandVolume = 0;

    [SerializeField] private bool _isReadyMixture;

    [Header("Filler")]
    [SerializeField] private Transform fillerTransform;
    [SerializeField] private Transform sandTransform;
    [SerializeField] private Renderer fillerRender;
    
    [Header("Filler Materials")]
    [SerializeField] private Material gluerMaterial;
    
    [FormerlySerializedAs("minRadius")]
    [Header("Filler Const")]
    [SerializeField] float minFillerRadius = 0.015f;
    [SerializeField] float minFillerHeight = 0.00044f;
    [SerializeField] float maxFillerRadius = 0.019f;
    [SerializeField] float maxFillerHeight = 0.01394f;

    private void Start()
    {
        ChangeFiller();
    }

    void Update()
    {
        Spill();
    }

    // Метод для виливания ведра
    private void Spill()
    {
        if (!spillable) return;

        if (spillable.IsSpilling && !spillingAudio.isPlaying)
        {
            _sandVolume = Mathf.Max(0, _sandVolume - Time.deltaTime);
            _waterVolume = Mathf.Max(0, _waterVolume - Time.deltaTime);
            spillingAudio?.Play();
        }
        else
        {
            spillingAudio?.Stop();
        }
    }

    private void ChangeFiller()
    {
        float fillerProcentage = (waterVolume + sandVolume) / maxVolume;
        float sandProcentage = sandVolume / maxVolume;

        float newFillerRadius = Mathf.Lerp(minFillerRadius,maxFillerRadius,  fillerProcentage);
        float newFillerHeight = Mathf.Lerp(maxFillerHeight,minFillerHeight,  fillerProcentage);
        
        float newSandRadius = Mathf.Lerp(minFillerRadius,maxFillerRadius,  sandProcentage);
        float newSandHeight = Mathf.Lerp(maxFillerHeight,minFillerHeight,  sandProcentage);

        fillerTransform.localPosition = 
            new Vector3(0, newFillerHeight, 0);
        fillerTransform.localScale = new Vector3(newFillerRadius, 0.001f, newFillerRadius);

        sandTransform.localPosition =
            new Vector3(0, newSandHeight, 0);
        sandTransform.localScale = new Vector3(newSandRadius, 0.001f, newSandRadius);
    }

    public float waterVolume
    {
        set { 
            if (value < 0) return;
            
            _sandVolume = Mathf.Min(maxVolume - _sandVolume, value);
            
            ChangeFiller();
        }

        get { return _waterVolume; }
    }

    public float sandVolume
    {
        set
        {
            if (value < 0) return;

            _sandVolume = Mathf.Min(maxVolume - _waterVolume, value);

            ChangeFiller();
        }

        get { return _sandVolume; }
    }

    public bool isReadyMixture
    {
        set { 
            _isReadyMixture = value;

            if (isReadyMixture)
                fillerRender.material = gluerMaterial;
        }
        get { return _isReadyMixture; }
    }
}