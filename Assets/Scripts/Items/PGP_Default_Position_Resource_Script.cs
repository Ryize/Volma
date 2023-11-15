using UnityEngine;

public class PGP_Default_Position_Resource_Script : MonoBehaviour
{
    /*
     * Класс отвечающий за изначальное положение ПГП.
     */
    public Vector3 defaultPosition;

    public void setDefaultPosition() {
        /*
         * Перемещаем ПГП на изначальную позицию
         */
        transform.position = defaultPosition;
    }
}
