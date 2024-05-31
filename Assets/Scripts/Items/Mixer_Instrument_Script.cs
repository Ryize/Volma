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

    // Скрипт анимации миксера
    [SerializeField]
    private Mixer_Animation_Instrument_Script mixerAnimation;

    // Компонент Rigidbody руки
    private Rigidbody leftHandRigidbody;
    private Rigidbody rightHandRigidbody;

    // Компонент Interactable миксера
    [SerializeField]
    private Interactable mixerInteractable;

    // Репозиторий предметов
    [SerializeField]
    private Item_Repository repository;

    private Bucket_Item_Script cachedBucket = null;

    private void Start()
    {
        //leftHandRigidbody = GameObject.Find("HandColliderLeft(Clone)").GetComponent<Rigidbody>();
        //rightHandRigidbody = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
    }

    /*
     * Метод вызывающийся автоматически, при касании миксера с объектом.
     *
     * Отслеживается песок, тк только раствор в ведре может размешиваться.
     *
     * Args:
     *  other: Collider (объект, которого мы коснулись)
     */

    private void OnTriggerStay(Collider filler)
    {

        if (!mixerInteractable.attachedToHand)
            return;
        
        // Если объект не ведро
        if (!filler.transform.name.ToLower().Contains("filler"))
        {
            return;
        }

        Rigidbody handRigidbody;
        
        // Получаем Rigidbody руки, в которой лежит мискер
        if (mixerInteractable.attachedToHand.handType == SteamVR_Input_Sources.LeftHand)
        {
            //handRigidbody = leftHandRigidbody;
            handRigidbody = GameObject.Find("HandColliderLeft(Clone)").GetComponent<Rigidbody>();
        }
        else
        {
            //handRigidbody = rightHandRigidbody;
            handRigidbody = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
        }

        // Получаем скорость замешивания
        float speed = mixerAnimation.speed * Mathf.Min(handRigidbody.velocity.magnitude, 1);

        if (!cachedBucket || filler.transform.parent != cachedBucket.transform){
            cachedBucket = filler.transform.parent.GetComponent<Bucket_Item_Script>();
        }

        cachedBucket.MixFiller(speed);
    }
}
