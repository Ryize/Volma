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
    
    // Частицы пыли
    private ParticleSystem _dustEffect; 

    // Звук подметания
    private AudioSource _sweepSound;
    
    // Репозиторий предеметов
    public Item_Repository repa;

    private void Start()
    {
        _sweepSound = GetComponent<AudioSource>();
        _dustEffect = GetComponent<ParticleSystem>();
    }
    
    /*
     * Метод подметания
     *
     * Отвечает за обработку соприкосания колайдеров метлы и глрязи
     *
     * Args:
     *  other: Collider (коллайдер вошедший в коллайдер грязи)
     */
    private void OnTriggerEnter(Collider other) {
        // Объектом должна быть метла
        if (!other.transform.name.ToLower().Contains("broom"))
            return;

        _Counter--;

        // Старт эффекта пыли
        _dustEffect.Play();
        
        // Старт звука подметания
        _sweepSound.Play();

        // Удаление грязи при обнулении счетчика
        if (_Counter < 0)
        {
            gameObject.SetActive(false); // отключаем объект грязи
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
