using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Bucket_Item_Script : MonoBehaviour
{
    [Header("Spilling")]
    [SerializeField] private Spillable spillable;
    [SerializeField] AudioSource spillingAudio;

    [Header("Bucket volume")]
    [SerializeField] private float maxVolume = 20;
    [SerializeField] private float _waterVolume;
    [SerializeField] private float _sandVolume;
    [SerializeField] private TMP_Text status;

    [Header("Mixture")]
    [SerializeField] private bool _isReadyMixture;
    [SerializeField] private CounterTracker mixtureProcces;

    [Header("Filler")]
    [SerializeField] private Transform fillerTransform;
    [SerializeField] private Transform sandTransform;
    [SerializeField] private Renderer fillerRender;

    [Header("Filler Materials")] 
    [SerializeField] private Material waterMaterial;
    [SerializeField] private Material glueMaterial;
    
    [FormerlySerializedAs("minRadius")]
    [Header("Filler Const")]
    [SerializeField] float minFillerRadius;
    [SerializeField] float minFillerHeight;
    [SerializeField] float maxFillerRadius;
    [SerializeField] float maxFillerHeight;

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

        if (spillable.IsSpilling)
        {
            sandVolume = Mathf.Max(0, _sandVolume - Time.deltaTime * 2);
            waterVolume = Mathf.Max(0, _waterVolume - Time.deltaTime * 2);
            if (!spillingAudio.isPlaying) spillingAudio.Play();
        }
        else
        {
            if (spillingAudio.isPlaying) spillingAudio.Stop();
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
        
        isReadyMixture = false;

        UpdateStatus();
    }

    public float waterVolume
    {
        set { 
            if (value < 0) return;
            
            _waterVolume = Mathf.Min(maxVolume - _sandVolume, value);
            
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

    public void MixFiller(float speed)
    {
        mixtureProcces.tracker += speed;

        if (mixtureProcces.tracker > 100)
        {
            isReadyMixture = true;
        }
    }

    public bool isReadyMixture
    {
        set { 
            _isReadyMixture = value;

            if (value)
                fillerRender.material = glueMaterial;
            else{
                fillerRender.material = waterMaterial;
                mixtureProcces.tracker = 0;
            }
        }
        get { return _isReadyMixture; }
    }

    private void UpdateStatus()
    {
        if (!isReadyMixture)
        {
            status.SetText($"цемент: {_sandVolume:F1}кг.\nвода: {_waterVolume:F1}л.\nвсего: {(_waterVolume + _sandVolume):F1}");
        }
        else
        {
            status.SetText("смесь готова.");
        }
    }
}
