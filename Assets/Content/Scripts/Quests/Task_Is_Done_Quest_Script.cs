using UnityEngine;

public class Task_Is_Done_Quest_Script : MonoBehaviour
{
    /*
     * Абстрактный класс, сообщающий готов ли квест или нет
     */
    
    public virtual bool isDone()
    {
        /*
         * Возвращает готовность квеста
        */
        return true;
    }
}
