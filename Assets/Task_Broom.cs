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
            task.changeDescription("Вы справились с первым заданием!");
            task.clearProgress();
            return true;
        }
        // Метла в пуке
        if (BroomInHand())
        {
            task.changeDescription("Подойдите к грязи и вытрети её");
            task.changeProgress((4 - dirts.Length).ToString() + "/4");
            task.changeHint("Зажмите ЛКМ и водите курсором по грязи");
            return false;
        }
        
        task.setTask("Чистка пола", "Возьмите метлу");
        task.clearProgress();
        return false;
    }
}
