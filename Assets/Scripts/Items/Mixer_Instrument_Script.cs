using Unity.VisualScripting;
using UnityEngine;

public class Mixer_Instrument_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за логику замешивания раствора в ведре
    */
    // Объект миксера
    public GameObject mixerAuger;
    // Показывает, сколько осталось смешивать. Аналог ХП замешивания
    public float bucketMixing = 10;
    // ПГП
    public GameObject pgpEvents;
    
    private void OnTriggerEnter(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при касании миксера с объектом.
         *
         * Отслеживается именно ведро, тк только раствор в ведре может размешиваться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        
        // Если не миксер завершаем функцию
        if (other.transform.parent.GameObject() != mixerAuger)
            return;
        
        // Получаем скорость замешивания
        float speed = mixerAuger.GetComponent<Mixer_Animation_Instrument_Script>().GetSpeed();

        bucketMixing -= speed;

        // Если мы замешали раствор
        if (bucketMixing < 0.1)
        {
            transform.parent.GetChild(3).gameObject.SetActive(true);
            transform.GameObject().SetActive(false);
            pgpEvents.SetActive(true);
        }
    }
}
