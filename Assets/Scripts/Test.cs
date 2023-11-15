using UnityEngine;

public class Test : Base
{
    /*
     * Тестовый класс.
     *
     * Реализует логику квеста.
     */
    
    // Предмет(ы)
    public GameObject cube;
    // Репозиторий предеметов
    public Item_Repository repa;

    /*
     * Стартовый метод
     *
     * Следит за положением предмета каждую секунду
     */
    private void Start()
    {
        InvokeRepeating("FallStatus", 0f, 1f);
    }

    /*
     * Квестовый метод
     *
     * Следит за тем, чтобы предмет был выше определенной позиции
     */
    private void FallStatus()
    {
        if (cube.transform.position.y < 1)
        {
            repa.Test_fallStatus = true;
        }
        else
        {
            repa.Test_fallStatus = false;
        }
    }
}
