using Unity.VisualScripting;
using UnityEngine;

public class Task_Primer : Task
{
    public GameObject arm; // рука
    public TextPrint task; // UI квеста

    // Проверка на выполнение квеста
    public override bool isDone()
    {
        // Выролнен ли квест
        if (GameObject.Find("PGPZone").transform.childCount == 0)
        {
            task.ChangeDescription("Вы справились с заданием!");
            task.ClearAuxiliaryLabels();
            return true;
        }

        // Есть ли грунтовка в кюветке нет
        if (!GameObject.FindGameObjectWithTag("cuvette_item").transform.GetChild(1).GameObject().activeSelf)
        {
            if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("primer"))
            {
                task.SetTask("Грунтовка","Возьмите грунтовку");
                task.ChangeHint("Грунтовка - это синий квадрат с этикеткой Волма");
                task.ClearProgress();
                return false;
            }
            
            task.ChangeDescription("Налейте грунтовку в кюветку");
            task.ClearAuxiliaryLabels();
            return false;
        }

        // Если валика нет в руках
        if (arm.transform.childCount == 0 || !arm.transform.GetChild(0).transform.tag.Contains("roller"))
        {
            task.ChangeDescription("Возьмите валик");
            task.ClearAuxiliaryLabels();
            return false;
        }

        // Если на валике нет грунтовки
        if (arm.transform.GetChild(0).transform.GetComponent<PaintRoller_Script>().paintFlowTracker < 0.1)
        {
            task.ChangeDescription("Обмакните валик в кюветку");
            task.ChangeHint("Подойдите к кюветке и водите по ней валиком");
            task.ClearProgress();
            return false;
        }

        task.ChangeDescription("Намажте грунтовку на выделенную зону");
        task.ChangeHint("Зона выделена зелеными прямоугольниками. Для нанесения водите по области валиком");
        task.ChangeProgress((14 - GameObject.Find("PGPZone").transform.childCount).ToString() + "/14");
        return false;
    }
}
