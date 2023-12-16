using System;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Mixer_Instrument_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за логику замешивания раствора в ведре
    */
    
    // Показывает, сколько осталось смешивать. Аналог ХП замешивания
    private CounterTracker bucketMixing;

    // Скрипт анимации миксера
    private Mixer_Animation_Instrument_Script mixerAnimation;

    private Rigidbody handRigidbody;

    private Interactable mixerInteractable;

    public Item_Repository repository;

    private void Start()
    {
        mixerAnimation = transform.GetComponent<Mixer_Animation_Instrument_Script>();
        mixerInteractable = transform.GetComponent<Interactable>();
    }

    private void OnTriggerEnter(Collider sand)
    {
        /*
         * Метод вызывающийся автоматически, при касании миксера с объектом.
         *
         * Отслеживается именно ведро, тк только раствор в ведре может размешиваться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        
        if (!mixerInteractable.attachedToHand)
            return;
        
        // Если объект не ведро
        if (!sand.transform.name.ToLower().Contains("sand"))
        {
            return;
        }
        
        // Получаем Rigidbody руки, в которой лежит мискер
        if (mixerInteractable.attachedToHand.handType == SteamVR_Input_Sources.LeftHand)
        {
            handRigidbody = GameObject.Find("HandColliderLeft(Clone)").GetComponent<Rigidbody>();
        }
        else
        {
            handRigidbody = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
        }
        
        // Получаем скорость замешивания
        float speed = mixerAnimation.GetSpeed() * Mathf.Min(handRigidbody.velocity.magnitude, 1);
        
        // Увеличиваем трекер
        bucketMixing = sand.GetComponent<CounterTracker>();
        bucketMixing.tracker += speed;

        // Если мы замешали раствор
        if (bucketMixing.tracker > 10)
        {
            sand.transform.parent.GetChild(3).gameObject.SetActive(true);
            sand.transform.GameObject().SetActive(false);
            repository.Bucket_Quest_isComplete = true;
        }
    }
}
