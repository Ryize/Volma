using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHammerSound : MonoBehaviour
{
    public AudioClip hammerSound;
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onSelectEntered.AddListener(PlayHammerSound);
    }

    void PlayHammerSound(XRBaseInteractor interactor)
    {
        audioSource.clip = hammerSound;
        audioSource.Play();
    }
}