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
        if (broom.tag.ToLower().Contains("broom"))
        {
            return true;
        }
        
        return false;
    }

    // Проверка на выполнение квеста
    public override bool isDone()
    {
        // проверка на выполнение квеста
        var dirts = GameObject.FindGameObjectsWithTag("Dirt");
        if (dirts.Length == 0)
        {
            task.changeDescription("Вы справились с первым заданием!");
            task.changeProgress("2/2");
            return true;
        }
        // метла в пуке
        if (BroomInHand())
        {
            task.changeDescription("Подойдите к грязи и вытрети её");
            task.changeProgress("1/2");
            task.changeHint("Зажмите ЛКМ и водите курсором по грязи");
            return false;
        }
        
        task.setTask("Чистка пола", "Возьмите метлу");
        task.changeProgress("0/2");
        return false;
    }
}
