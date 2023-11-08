using UnityEngine;

public class Pallet_Instrumnet_Script : MonoBehaviour
{
    /*
     * Отвечает за нанесения клея на ПГП
    */
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
        
        // Если объект не ведро с клеем, то заканчиваем функцию
        if (!(other.tag.ToLower().Contains("task") || other.tag.ToLower().Contains("basket")))
            return;
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
        
        // Если на шпателе есть клей, то но заканчиваем функцию
        if (meshRenderer.enabled) {
            return;
        }
        // Если объект ведро, раствор замешен и на шпателе нет клея, то на шпателе появится клей
        if (otherName.Contains("basket") && 
            other.transform.parent.GetChild(3).gameObject.activeSelf) {
            meshRenderer.enabled = true;
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
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
        Transform eventZone = other.transform.parent;

        // Если на шпателе есть клей и объект горизонтальная или вертикальная зона
        // (зона, куда наносится клей, чтобы закрепить ПГП).
        // То удаляем зону нанесения клея и убираем клей со шпателя.
        if (meshRenderer.enabled && 
        (otherName.Contains("horizontalzone") || otherName.Contains("verticalzone"))) {
            Destroy(other.transform.gameObject);
            meshRenderer.enabled = false;
        }

        // Если пгп не активна
        if (!eventZone.GetChild(0).gameObject.activeSelf)
            return;

        // Объект горизонтальная или вертикальная зона
        // (зона, куда наносится клей, чтобы закрепить ПГП).
        // То удаляем зону нанесения клея.
        if (otherName.Contains("horizontalglue") || otherName.Contains("verticalglue")) {
            Destroy(other.transform.gameObject);
        }
    }
}
