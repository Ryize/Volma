using UnityEngine;

public class Sweep_Quest_Script : Quest
{
    /*
     * Класс грязи
     *
     * Реализует логику подметания грязи.
     */
    
    // Счетчик отвечающий за кол-во подметаний
    private int _Counter = 4;

    // Pвук подметания
    private AudioSource _sweepSound;

    // Репозиторий предеметов
    public Item_Repository repa;

    /*
     * Метод подметания
     *
     * Отвечает за обработку соприкосания колайдеров метлы и глрязи
     *
     * Args:
     *  other: Collider (коллайдер вошедший в коллайдер грязи)
     */
    private void OnTriggerEnter(Collider other) {
        _sweepSound = GetComponent<AudioSource>();
        // Объектом должна быть метла
        if (!other.transform.name.ToLower().Contains("broom"))
            return;
        
        _Counter--;

        _sweepSound.Play();

        // Удаление грязи при обнулении счетчика
        if (_Counter < 0)
        {
            repa.DirtsAmount -= 1;
            gameObject.SetActive(false);
        }
    }

    /*
     * Метод отключения объекта
     *
     * При отключении объекта уменьшает кол-во грязи в репозитории
     */
    private void OnDisable()
    {
        repa.DirtsAmount -= 1;
    }

    /*
     * Метод включения объекта
     *
     * При включении объекта увеличивает кол-во грязи в репозитории
     */
    private void OnEnable()
    {
        repa.DirtsAmount += 1;
    }
}
