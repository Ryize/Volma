using Unity.VisualScripting;
using UnityEngine;

public class Task_Primer : Task
{
    public GameObject arm; // рука
    public TextPrint task; // UI квеста
    
    /*private bool BroomInHand()
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
    }*/

    // Проверка на выполнение квеста
    public override bool isDone()
    {
        // Выролнен ли квест
        if (GameObject.Find("PGPZone").transform.childCount == 0)
        {
            task.setTask("Вы справились с заданием!");
            return true;
        }

        // Есть ли грунтовка в кюветке нет
        if (!GameObject.FindGameObjectWithTag("cuvette_item").transform.GetChild(1).GameObject().activeSelf)
        {
            if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("primer"))
            {
                task.setTask("возьмите грунтовку");
                return false;
            }
            
            task.setTask("налейте грунтовку в кюветку");
            return false;
        }

        // Если валика нет в руках
        if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("roller"))
        {
            task.setTask("Возьмите валик");
            return false;
        }

        // Если на валике нет грунтовки
        if (arm.transform.GetChild(0).transform.GetComponent<PaintRoller_Script>().paintFlowTracker < 0.1)
        {
            task.setTask("Обмакните валик в кюветку");
            return false;
        }

        task.setTask("Намажте грунтовку на выделенную зону");
        return false;
    }
}
