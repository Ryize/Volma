using Unity.VisualScripting;
using UnityEngine;
public class Task_Broom : Task
{
    public GameObject arm; // рука
    public TextPrint task; // UI квеста
    private bool BroomInHand()
    {
        
        // проверка на наличие предмета
        if (arm.transform.childCount == 0)
            return false;
        
        // получение объекта из руки
        GameObject broom = arm.transform.GetChild(0).GameObject();

        // проверка на тэг метлы
        if (!broom.tag.ToLower().Contains("broom"))
        {
            return false;
        }
        
        return true;
    }

    // Проверка на выполнение квеста
    public override bool isDone()
    {
        // проверка на выполнение квеста
        var dirts = GameObject.FindGameObjectsWithTag("Dirt");
        if (dirts.Length == 0)
        {
            task.setTask("Чистка пола", "Вы справились с первым заданием!");
            return true;
        }
        // метла в пуке
        if (BroomInHand())
        {
            task.setTask("Чистка пола", "Подойдите к грязи и вытрети её Подойдите к грязи и вытрети её Подойдите к грязи и вытрети её");
            return false;
        }
        
        task.setTask("Чистка пола", "Возьмите метлу!");
        return false;
    }
}
