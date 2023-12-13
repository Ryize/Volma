using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelSwitchScript : MonoBehaviour
{

    private float _lastRotation;
    private AudioSource radioAudioSource;
    void Start()
    {
        radioAudioSource = GetComponent<AudioSource>();
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
        Debug.Log(_lastRotation);
    }
}
