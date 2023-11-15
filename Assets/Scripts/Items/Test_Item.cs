using System.Collections.Generic;
using UnityEngine;


public class Test_Item : Base
{
    /*
     * Тестовый класс.
     *
     * Реализует логику телепортации куба.
     */
    
    // Куб который телепортируется
    public GameObject cube;
    
    // Менеджер объектов
    public Item_Manager manager;

    // Тип событий, который отслеживается 
    public List<string> subTypes;
    
    /*
     * Стартовый метод
     *
     * Реализует механизм подписки
     */
    void Start()
    {
        foreach (var type in subTypes)
        {
            manager.subscribe(type, this);
        }
    }
    
    /*
     * Метод уведомления о событии.
     *
     * Отслеживается событие падения кубика.
     * 
     * Args:
     *  a: string (тип события)
     *  status: bool (состояние кубика)
     */
    public override void Notify(string a, bool status)
    {
        TeleportCube();
    }

    /*
     * Метод телепортации куба
     *
     * Телепортирует куб
     */
    private void TeleportCube()
    {
        cube.transform.position = new Vector3(0, 2, 0);
        cube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
