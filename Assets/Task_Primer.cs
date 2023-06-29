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
            task.changeDescription("Вы справились с заданием!");
            task.clearHint();
            task.clearProgress();
            return true;
        }

        // Есть ли грунтовка в кюветке нет
        if (!GameObject.FindGameObjectWithTag("cuvette_item").transform.GetChild(1).GameObject().activeSelf)
        {
            if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("primer"))
            {
                task.setTask("Грунтовка","Возьмите грунтовку");
                task.changeHint("Грунтовка - это синий квадрат с этикеткой Волма");
                task.clearProgress();
                return false;
            }
            
            task.changeDescription("Налейте грунтовку в кюветку");
            task.clearHint();
            task.clearProgress();
            return false;
        }

        // Если валика нет в руках
        if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("roller"))
        {
            task.changeDescription("Возьмите валик");
            task.clearHint();
            task.clearProgress();
            return false;
        }

        // Если на валике нет грунтовки
        if (arm.transform.GetChild(0).transform.GetComponent<PaintRoller_Script>().paintFlowTracker < 0.1)
        {
            task.changeDescription("Обмакните валик в кюветку");
            task.changeHint("Подойдите к кюветке и водите по ней валиком");
            task.clearProgress();
            return false;
        }

        task.changeDescription("Намажте грунтовку на выделенную зону");
        task.changeHint("Зона выделена зелеными прямоугольниками. Для нанесения водите по области валиком");
        task.changeProgress((14 - GameObject.Find("PGPZone").transform.childCount).ToString() + "/14");
        return false;
    }
}
