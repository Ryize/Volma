using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelSwitchScript : MonoBehaviour
{
    [Header("List of Tracks")] 
    [SerializeField] private RadioTrackScript[] audioTracks;

    private int trackIndex;
    
    private float _lastRotation;
    private AudioSource radioAudioSource;
    void Start()
    {
        radioAudioSource = GetComponent<AudioSource>();
        trackIndex = -1;
        radioAudioSource.clip = audioTracks[trackIndex].trackAudioClip;
    }
    
    public void UpdateTrack(int index)
    {
        if (index != -1)
        {
            radioAudioSource.clip = audioTracks[index].trackAudioClip;
        }
    }
    public void PlayAudio()
    {
        radioAudioSource.Play();
    }

    public void StopAudio()
    {
        radioAudioSource.Stop();
    }
    
    // Update is called once per frame
    void Update()
    {
        //float spinMagnitude = Quaternion.Angle(Quaternion.Euler(_lastRotation), transform.rotation);
        _lastRotation = transform.localRotation.eulerAngles.y;
        if (_lastRotation >= 30 && _lastRotation <= 60)
        {
            UpdateTrack(1);
            Debug.Log("1");
            PlayAudio();
        }
        else if (_lastRotation >= 120 && _lastRotation <= 150)
        {
            UpdateTrack(2);
            Debug.Log("2");
            PlayAudio();
        }
        else if (_lastRotation >= 210 && _lastRotation <= 240)
        {
            UpdateTrack(3);
            Debug.Log("3");
            PlayAudio();
        }
        else if (_lastRotation >= 300 && _lastRotation <= 330)
        {
            UpdateTrack(4);
            Debug.Log("4");
            PlayAudio();
        }
        else if (_lastRotation>=0 && _lastRotation<=15)
        {
            StopAudio();
            Debug.Log("стоп");
        }
        else
        {
            UpdateTrack(0);
            PlayAudio();
            Debug.Log("шум");
        }

    }
}
