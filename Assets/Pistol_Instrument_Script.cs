using System;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pistol_Instrument_Script : Base
{
    private SteamVR_Action_Single buttonTrigger;

    private AudioSource pistolAudioSource;

    private Interactable interactable;

    [Header("Item Repository")]
    [SerializeField] private Item_Repository repository;

    private void Start()
    {
        buttonTrigger = SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");
        interactable = GetComponent<Interactable>();

        pistolAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            bool isActive = buttonTrigger.GetAxis(hand) > 0.1f;
            
            // Проверяем, активен ли триггер кнопки и аудио не проигрывается.
            if (isActive && !pistolAudioSource.isPlaying)
            {
                // Запускаем проигрывание аудио.
                pistolAudioSource.Play();
            }

            // Проверяем, не активен ли триггер кнопки и аудио проигрывается.
            if (!isActive && pistolAudioSource.isPlaying)
            {
                // Останавливаем проигрывание аудио.
                pistolAudioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform foam = other.transform;

        if (!foam.name.ToLower().Contains("foam"))
        {
            return;
        }
        
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            bool isActive = buttonTrigger.GetAxis(hand) > 0.1f;

            if (isActive)
            {
                foam.GetComponent<MeshRenderer>().enabled = true;
                foam.GetComponent<Collider>().isTrigger = false;
                repository.FoamAmount--;
            }
        }
    }
}
