using UnityEngine;

public class Faucet_Zone : MonoBehaviour
{
    /*
     * Скрипт для проверки зашло ли ведро в зону крана
    */
    // Объект руки
    public GameObject handle;

    private void OnTriggerStay(Collider other)
    {
        /*
         * Метод отслеживает прикосновение к объекту
        */
        
        // Если объект который мы коснулись не ведро, выходим из метода
        if (!other.transform.name.ToLower().Contains("bucket"))
        {
            return;
        }

        other.transform.parent.GetComponent<CounterTracker>().tracker 
            += (Mathf.Sin(handle.transform.eulerAngles.y)) * Time.deltaTime;
    }
}
