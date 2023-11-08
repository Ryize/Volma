using UnityEngine;

public class CounterTracker : MonoBehaviour
{
    /*
     * Класс счетчик
     *
     * Реализует логику подсчета чего-нибудь
     */
    
    // Счетчик
    public float tracker;
    // Уничтожать ли объект, при обнулении
    public bool destroyEmpty;
    
    /*
     * Метод реализующий удаление объекта
     */
    void Update()
    {
        // Если мы хотим уничтожить объект при обнулении счетчика и счетчик равен нулю, то объект уничтожается
        if (destroyEmpty && tracker < 0.1f)
        {
            Destroy(this);
        }
    }
}
