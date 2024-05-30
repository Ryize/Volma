using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за засыпание цемента в ведро с водой.
    */

    // Статистика
    [SerializeField] private Stats stats;

    [SerializeField] private Spillable spillable;

    [SerializeField] private ParticleSystem sandLeak;

    [SerializeField] private AudioSource bagSpillingSound;

    [SerializeField] private Rigidbody bagRigidbody;

    private void Update()
    {
        Spill();
    }

    private void Spill()
    {
        // Песок должен высыпаться
        if (spillable == null || !spillable.IsSpilling) {
            sandLeak.maxParticles = 0;
            return;
        }

        sandLeak.maxParticles = 10;

        if (bagSpillingSound != null && !bagSpillingSound.isPlaying) bagSpillingSound.Play();
        else bagSpillingSound.Stop();

        Bucket_Item_Script bucket = BucketRaycast();

        float cement = bagRigidbody.velocity.magnitude * 5 + 1;

        stats.cement += cement;

        if (bucket != null)
        {
            bucket.sandVolume += cement;
        }
    }

    private Bucket_Item_Script BucketRaycast()
    {
        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;

        // Максимальная дистанция для засыпания
        float distance = 10f;

        RaycastHit bucket;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out bucket, distance))
        {
            return null;
        }

        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("water"))
        {
            return null;
        }

        return bucket.transform.GetComponent<Bucket_Item_Script>();
    }

    /*
    
    // Счетчик ведра
    private CounterTracker bucketFillAmount;

    // Статистика
    [SerializeField] private Stats stats;
    
    // Эффект мешка
    private ParticleSystem sandLeak;

    //звук высыпания из мешка
    private AudioSource _bagMovementSound;

    *//*
     * Стартовый метод
     *
     * Определяет компоненты ведра
     *//*
    private void Start()
    {
        *//*
         * Запускаем скрипт проверки на засыпания раз в секунду
        *//*
        InvokeRepeating("FallingCement", 1f, 1f);

        sandLeak = transform.GetChild(0).GetComponent<ParticleSystem>();
        _bagMovementSound = GetComponent<AudioSource>();

        sandLeak.maxParticles = 0;
    }

    *//*
     * Метод позволяющий засыпать цемент.
     *
     * Запускается раз в секунду и при выполнении условий засыпает цемент.
     *//*
    void FallingCement()
    {
        // Если мешок перевернут
        float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

        if (cosX * cosZ <= -0.1f)
        {
            sandLeak.maxParticles = 10;
            
            // звук высыпания из мешка
            _bagMovementSound.Play();
        }
        else 
        {
            sandLeak.maxParticles = 0;
            
            _bagMovementSound.Pause();
            return;
        }
 
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
        
        // Если объект не ведро
        if (!bucket.transform.name.ToLower().Contains("bucket") &&
            !bucket.transform.name.ToLower().Contains("water"))
        {
            return;
        }
        
        // Если текущее ведро, не ведро с водой, то заканчиваем выполнение метода
        if (!bucket.transform.GetChild(1).gameObject.activeSelf)
            return;

        bucketFillAmount = bucket.transform.GetComponent<CounterTracker>();

        float cement = transform.GetComponent<Rigidbody>().velocity.magnitude * 5 + 1;
        
        bucketFillAmount.tracker += cement;

        // Добавление цемента в статистику
        stats.cement += cement;

        Debug.Log("[Bag_Script] bucketFillAmount: " + bucketFillAmount.tracker);

        // Меняем ведро с водой, на ведро с цементом
        if (bucketFillAmount.tracker > 6f)
        {
            bucket.transform.GetChild(2).gameObject.SetActive(true);
            bucket.transform.GetChild(1).gameObject.SetActive(false);
            bucketFillAmount.tracker = 0;
        }
    }*/
}