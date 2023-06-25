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
            task.setTask("Вы справились с первым заданием!");
            return true;
        }
        // метла в пуке
        if (BroomInHand())
        {
            task.setTask("Подойдите к грязи и вытрети её (зажав левую кнопку, и двигая курсором)");
            return false;
        }
        
        task.setTask("Возьмите метлу");
        return false;
    }
}
