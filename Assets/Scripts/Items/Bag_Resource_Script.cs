using UnityEngine;

public class Bag_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за засыпание цемента в ведро с водой.
    */
    // Сколько осталось цемента для заполнения ведра
    public float bucketFillAmount;

    // Объект ведра
    public GameObject bucket;

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

    private void Update()
    {
    stats.GetComponent<Stats>().cement += 1.257f;
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

        // Если текущее ведро, не ведро с водой, то заканчиваем выполнение метода
        if (!bucket.transform.GetChild(1).gameObject.activeSelf)
            return;

        Vector3 origin = transform.position;
        Vector3 derection = Vector3.down;

        // Максимальная дистанция для засыпания
        float distance = 10f;

        RaycastHit hit;

        // Если дистанция слишком большая
        if (!Physics.Raycast(origin, derection, out hit, distance))
        {
            return;
        }
        // Если объект не ведро
        if (!hit.transform.name.Contains("bucketVR"))
        {
            return;
        }

        // звук насыпания в ведро
        bucketFillAmount -= transform.GetComponent<Rigidbody>().velocity.magnitude;

        // Меняем ведро с водой, на ведро с цементом
        if (bucketFillAmount < 0.1)
        {
            stats.GetComponent<Stats>().cement += 1f;
            bucket.transform.GetChild(2).gameObject.SetActive(true);
            bucket.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}