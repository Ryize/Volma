using UnityEngine;

public class Bucket_Item_Script : MonoBehaviour
{
    [SerializeField] private Spillable spillable;

    [SerializeField] private float maxVolume = 20;

    [SerializeField] private float _waterVolume = 0;

    [SerializeField] private float _sandVolume = 0;

    [SerializeField] private bool _isReadyMixture;

    [SerializeField] AudioSource spillingAudio;

    [SerializeField] private GameObject filler;
    [SerializeField] private Renderer fillerRender;
    [SerializeField] private Material sandMaterial;
    [SerializeField] private Material gluerMaterial;

    void Update()
    {
        Spill();
    }

    // Метод для виливания ведра
    private void Spill()
    {
        if (spillable == null) return;

        if (spillable.IsSpilling && !spillingAudio.isPlaying)
        {
            _sandVolume -= Time.deltaTime;
            _waterVolume -= Time.deltaTime;
            spillingAudio?.Play();
        }
        else
        {
            spillingAudio?.Stop();
        }
    }

    public float waterVolume
    {
        set { 
            if (value < 0) return;

            if (value > maxVolume - _sandVolume) return;

            _waterVolume = value; 
        }

        get { return _waterVolume; }
    }

    public float sandVolume
    {
        set
        {
            if (value < 0) return;

            if (value > maxVolume - _waterVolume) return;

            _sandVolume = value;

            if (_sandVolume>0 && !isReadyMixture)
                fillerRender.material = sandMaterial;
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
