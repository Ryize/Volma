using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за засыпание цемента в ведро с водой.
    */
    
    private CounterTracker bucketFillAmount;

    public GameObject stats;

    //звук высыпания из мешка
    private AudioSource _bagMovementSound;

    private void Start()
    {
        /*
         * Запускаем скрипт проверки на засыпания раз в секунду
        */
        InvokeRepeating("FallingCement", 1f, 1f);
        _bagMovementSound = GetComponent<AudioSource>();
    }

    void FallingCement()
    {
        /*
         * Метод позволяющий засыпать цемент.
         *
         * Запускается раз в секунду и при выполнении условий засыпает цемент.
        */

        // Если мешок перевернут
        float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

        if (cosX * cosZ <= 0)
        {
            // звук высыпания из мешка
            _bagMovementSound.Play();
        }
        else 
        {
            _bagMovementSound.Pause();
            return;
        }
        
        Debug.Log("[Bag_Script] 1");
        stats.GetComponent<Stats>().cement += transform.GetComponent<Rigidbody>().velocity.magnitude * 6;
 
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;

        // Максимальная дистанция для засыпания
        float distance = 10f;

        RaycastHit bucket;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out bucket, distance))
        {
            return;
        }
        
        Debug.Log("[Bag_Script] 2");
        
        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("water"))
        {
            return;
        }
        
        Debug.Log("[Bag_Script] 3");
        
        // Если текущее ведро, не ведро с водой, то заканчиваем выполнение метода
        if (!bucket.transform.GetChild(1).gameObject.activeSelf)
            return;
        
        Debug.Log("[Bag_Script] 4");

        bucketFillAmount = bucket.transform.GetComponent<CounterTracker>();
        
        bucketFillAmount.tracker += transform.GetComponent<Rigidbody>().velocity.magnitude;
        
        Debug.Log("[Bag_Script] bucketFillAmount: " + bucketFillAmount.tracker);

        // Меняем ведро с водой, на ведро с цементом
        if (bucketFillAmount.tracker > 1f)
        {
            bucket.transform.GetChild(2).gameObject.SetActive(true);
            bucket.transform.GetChild(1).gameObject.SetActive(false);
            bucketFillAmount.tracker = 0;
        }
    }
}