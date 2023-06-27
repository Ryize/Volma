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
        // Есть ли грунтовка в кюветке
        if (GameObject.FindGameObjectWithTag("cuvette_item").transform.GetChild(1).GameObject().activeSelf)
        {
            Debug.Log("Primer in cuvette");
        }
        
        

            //var primer = GameObject.FindGameObjectWithTag("cuvette_item").transform.GetChild(1).GameObject();
        //primer.SetActive(true);


        /*// проверка на выполнение квеста
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
        return false;*/
        return true;
    }
}
