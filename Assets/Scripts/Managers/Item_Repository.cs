using UnityEngine;

public class Item_Repository : Repository
{
    /*
     * Класс репозитория предметов
     *
     * Реализует логику работы и сохраниния данных.
     */
    
    // Статус положения ведра
    private bool _Bucket_Quest_isComplete;
    // Статус тестового квеста
    private bool _Test_fallStatus = false;
    // Статус квеста грязи
    private bool _Dirt_Quest_isComplete;
    
    // Кол-во грязи
    private int _DirtsAmount = 4;
    
    // Менеджер предметов
    public Item_Manager manager; 
    
    // Получение и установка статуса положения ведра
    public bool Bucket_Quest_isComplete
    {
        get
        {
            return _Bucket_Quest_isComplete;
        }
        set
        {
            _Bucket_Quest_isComplete = value;

            if (value)
            {
                manager.Notify_BucketQuestComplete(value);
            }
        }
    }
    
    // Получение и установка статуса тестового квеста
    public bool Test_fallStatus
    {
        get
        {
            return _Test_fallStatus;
        }
        set
        {
            _Test_fallStatus = value;
            if (value)
            {
                manager.Notify_Fall(value);
            }
        }
    }
    
    // Получение и установка статуса квеста грязи
    public bool Dirt_Quest_isComplete
    {
        get
        {
            return _Dirt_Quest_isComplete;
        }
        set
        {
            _Dirt_Quest_isComplete = value;
            if (value)
            {
                manager.Notify_DirtQuestComplete(value);
            }
        }
    }
    
    // Получение и установка кол-ва грязи
    public int DirtsAmount
    {
        get
        {
            return _DirtsAmount;
        }
        set
        {
            _DirtsAmount = value;
            if (value <= 0)
            {
                Dirt_Quest_isComplete = true;
            }
        }
    }
}
