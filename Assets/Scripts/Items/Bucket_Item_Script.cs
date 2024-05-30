using UnityEngine;

public class Bucket_Item_Script : MonoBehaviour
{
    private Spillable spillable;

    [SerializeField]
    private float maxVolume = 20;

    [SerializeField]
    private float _waterVolume = 0;

    [SerializeField]
    private float _sandVolume = 0;

    AudioSource spillingAudio;

    void Start()
    {
        spillable = GetComponent<Spillable>();
        spillingAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (spillable == null) return;

        if (spillable.IsSpilling && spillingAudio.isPlaying)
        {
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
        }

        get { return _sandVolume; }
    }
}
