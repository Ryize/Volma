using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mixer_Instrument_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за логику замешивания раствора в ведре
    */
    // Объект миксера
    private GameObject mixerAuger;
    // Показывает, сколько осталось смешивать. Аналог ХП замешивания
    private CounterTracker bucketMixing;
    // ПГП
    //public GameObject pgpEvents;

    private void Start()
    {
        mixerAuger = transform.GetChild(2).gameObject;
    }

    private void OnTriggerEnter(Collider bucket)
    {
        /*
         * Метод вызывающийся автоматически, при касании миксера с объектом.
         *
         * Отслеживается именно ведро, тк только раствор в ведре может размешиваться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        
        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("sand"))
        {
            return;
        }
        
        // Если текущее ведро, не ведро с цементом, то заканчиваем выполнение метода
        if (!bucket.transform.GetChild(2).gameObject.activeSelf)
            return;

        bucketMixing = bucket.GetComponent<CounterTracker>();
        
        // Получаем скорость замешивания
        float speed = mixerAuger.GetComponent<Mixer_Animation_Instrument_Script>().GetSpeed();

        
        bucketMixing.tracker += speed;

        // Если мы замешали раствор
        if (bucketMixing.tracker > 10)
        {
            transform.parent.GetChild(3).gameObject.SetActive(true);
            transform.GameObject().SetActive(false);
            //pgpEvents.SetActive(true);
        }
    }
}
