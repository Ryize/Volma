using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBladeSpin : MonoBehaviour
{
    public AudioClip spinSound;
    private AudioSource audioSource;
    private float spinThreshold1 = 180f; // Пороговое значение для определения поворота
    private float spinThreshold2 = 270f; // Пороговое значение для определения поворота

    private Vector3 lastRotation;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastRotation = transform.eulerAngles;
    }

    void Update()
    {
        float spinMagnitude = Quaternion.Angle(Quaternion.Euler(lastRotation), transform.rotation);

        if (spinMagnitude > spinThreshold1)//&& spinMagnitude < spinThreshold2)
        {
            audioSource.clip = spinSound;
            audioSource.Play();
        }

        lastRotation = transform.eulerAngles;
    }
}