using Unity.VisualScripting;
using UnityEngine;
public class Task_Broom : Task
{
    public GameObject arm; // рука
    public TextPrint task; // UI квеста
    private bool BroomInHand()
    {
        
        // Проверка на наличие предмета
        if (arm.transform.childCount == 0)
            return false;
        
        // Получение объекта из руки
        GameObject broom = arm.transform.GetChild(0).GameObject();

        // Проверка на тэг метлы
        if (broom.tag.ToLower().Contains("broom"))
        {
            return true;
        }
        
        return false;
    }

    // Проверка на выполнение квеста
    public override bool isDone()
    {
        // Проверка на выполнение квеста
        var dirts = GameObject.FindGameObjectsWithTag("Dirt");
        if (dirts.Length == 0)
        {
            task.ChangeDescription("Вы справились с первым заданием!");
            task.ClearProgress();
            return true;
        }
        // Метла в пуке
        if (BroomInHand())
        {
            task.ChangeDescription("Подойдите к грязи и вытрети её");
            task.ChangeProgress((4 - dirts.Length).ToString() + "/4");
            task.ChangeHint("Зажмите ЛКМ и водите курсором по грязи");
            return false;
        }
        
        // task.SetTask("Чистка пола", "Возьмите метлу");
        // task.ClearProgress();
        return false;
    }
}
