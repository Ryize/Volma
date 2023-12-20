using Unity.VisualScripting;
using UnityEngine;

public class PositionKeeper : MonoBehaviour
{
    /*
     * Класс отслеживающий положения объекта
     *
     * Нужен для того, чтобы телепортировать объект на своё место,
     * если он улетел за сцену
     */
    
    // Стандартная позиция объекта
    [SerializeField] private Vector3 defaultPosition;
    
    /*
     * Стартовый метод
     *
     * Проверяет не является ли позиция null и запускает метод для отслеживания объекта
     */
    void Start()
    {
        if (defaultPosition.IsUnityNull())
        {
            defaultPosition = new Vector3(0, 1, 0);
        }
        
        InvokeRepeating("KeepItem", 0, 1);
    }

    /*
     * Метод отслеживающий положение объекта
     *
     * Если объект вышел за границу, то объект телепортируется на своё стандартное место
     */
    private void KeepItem()
    {
        if (transform.position.x > 3.5f || transform.position.x < -3.5f || 
            transform.position.y > 4f || transform.position.y < -1f || 
            transform.position.z > 2f || transform.position.z < -2f
           )
        {
            transform.position = defaultPosition;
            
            if (transform.GetComponent<Rigidbody>())
            {
                transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
