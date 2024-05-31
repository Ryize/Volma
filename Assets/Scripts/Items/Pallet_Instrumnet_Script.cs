using System;
using UnityEngine;

public class Pallet_Instrumnet_Script : MonoBehaviour
{
    /*
     * Отвечает за нанесения клея на ПГП
    */

    [SerializeField]
    private MeshRenderer glueRenderer;

    private Transform task;

    private void OnTriggerEnter(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при касании клея с объектом.
         *
         * Отслеживается именно ведро с клеем.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
        */
        
        Debug.Log("[Pallet_Instrumnet_Script] target: " + other.name);
        // Если объект не ведро с клеем, то заканчиваем функцию
        if (!other.name.ToLower().Contains("filler"))
            return;

        if (!other.transform.parent.GetComponent<Bucket_Item_Script>().isReadyMixture)
        {
            return;
        }
       
        // Если на шпателе нет клея, то на шпателе появится клей
        if (!glueRenderer.enabled) {
            glueRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при выходе клея из колайдера объекта.
         *
         * Отслеживаются именно квестовые объекты.
         *
         * Args:
         *  other: Collider (объект, из которого мы вышли)
        */
        
        // Если объект не квестовый, то заканчиваем функцию
        if (!other.tag.ToLower().Contains("task"))
            return;

        task = other.transform;
        
        string otherName = task.name.ToLower();
        
        Transform eventZone = task.parent;

        // Если на шпателе есть клей и объект горизонтальная или вертикальная зона
        // (зона, куда наносится клей, чтобы закрепить ПГП).
        // То удаляем зону нанесения клея и убираем клей со шпателя.
        if (glueRenderer.enabled && 
        (otherName.Contains("horizontal_zone") || otherName.Contains("vertical_zone"))) {
            Destroy(task.gameObject);
            glueRenderer.enabled = false;
        }
        
        // Если пгп не активна
        if (!eventZone.GetChild(0).gameObject.activeSelf)
            return;

        // Объект горизонтальная или вертикальная зона
        // (зона, куда наносится клей, чтобы закрепить ПГП).
        // То удаляем зону нанесения клея.
        if (otherName.Contains("horizontal_glue") || otherName.Contains("vertical_glue")) {
            Destroy(task.gameObject);
        }
    }
}
