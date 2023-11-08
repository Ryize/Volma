using UnityEngine;

public class Saw_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт пилы.
     *
     * Позволяет разрезать объекты (ПГП) пополам.
    */
    
    // Ссылка на префаб pgpFrontVR
    public GameObject pgpFrontVR;
    // Ссылка на префаб pgpBackVR
    public GameObject pgpBackVR;
    // Rigidbody пилы
    public Rigidbody sawRigidbody;
    // Скорость пилы
    private float velocity;
    // Начальная прочность объекта
    private PGP_Strength_Resource_Script pgpStatus; 

    private void OnTriggerStay(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при касании пилы с объектом.
         *
         * Отслеживается именно ПГП, тк только он может разрезаться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        if (!other.transform.root.CompareTag("pgp_item"))
            return;

        velocity = sawRigidbody.velocity.magnitude;
        pgpStatus = other.transform.root.gameObject.GetComponent<PGP_Strength_Resource_Script>();
        pgpStatus.strength -= velocity;
        
        // Если ПГП уже разрезан, то мы не можем разрезать его ещё раз.
        if (pgpStatus.hasSliced)
            return;

        if (pgpStatus.strength < 0.1)
        {
            Split(other.transform.root.gameObject);
            pgpStatus.hasSliced = true;
        }
    }

    private void Split(GameObject other)
    {
        /*
         * Метод реализующий логику разделения (располовинивая) объектов при разрезании.
         *
         * Args:
         *  other: GameObject (объект, который столкнулась пила)
         */
        // Получаем позицию и поворот объекта, с которым столкнулась пила
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;

        // Уничтожаем объект
        //other.GetComponent<>()
        Destroy(other);

        // Создаем две половинки объекта pgpFrontVR и pgpBackVR
        Instantiate(pgpFrontVR, position, rotation);
        Instantiate(pgpBackVR, position, rotation);
    }
}
