using System;
using Unity.VisualScripting;
using UnityEngine;

public class Cuvette_Instrument_Script : MonoBehaviour
{
    [SerializeField] private float maxVolume = 2;
    [SerializeField] private float _primerVolume;
    
    [Header("Filler")]
    [SerializeField] private Transform fillerTransform;
    [SerializeField] private float minFillerScale;
    [SerializeField] private float minFillerHeight;
    [SerializeField] private float minFillerPosition;
    [SerializeField] private float maxFillerScale;
    [SerializeField] private float maxFillerHeight;
    [SerializeField] private float maxFillerPosition;

    private void Awake()
    {
        ChangeFiller();
    }

    private void ChangeFiller()
    {
        float fillerPercentage = primerVolume / maxVolume;

        float newFillerScale = Mathf.Lerp(minFillerScale, maxFillerScale, fillerPercentage);
        float newFillerHeight = Mathf.Lerp(minFillerHeight, maxFillerHeight, fillerPercentage);
        float newFillerPosition = Mathf.Lerp(minFillerPosition, maxFillerPosition, fillerPercentage);

        fillerTransform.localPosition = new Vector3(newFillerPosition, newFillerHeight, 0);
        fillerTransform.localScale = new Vector3(newFillerScale, 0.001f, 0.025f);
    }

    public float primerVolume
    {
        set
        {
            if (value < 0.01f) return;

            _primerVolume = Mathf.Min(maxVolume, value);
            
            ChangeFiller();
        }
        
        get { return _primerVolume; }
    }
}
