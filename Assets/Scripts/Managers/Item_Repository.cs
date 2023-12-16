using System;
using UnityEngine;

public class Item_Repository : Repository
{
    /*
     * Класс репозитория предметов
     *
     * Реализует логику работы и сохраниния данных.
     */
    
    // Менеджер предметов
    public Item_Manager manager; 
    
    // Статус положения ведра
    private bool _Bucket_Quest_isComplete;
    // Статус тестового квеста
    private bool _Test_fallStatus = false;
    // Статус квеста грязи
    private bool _Dirt_Quest_isComplete;
    // Статус квеста ПГП
    private bool _PGP_Quest_isComplete;
    // Статус зоны ПГП
    private bool _PGP_Zone_Quest_isComplete;
    
    // Кол-во грязи
    private int _DirtsAmount;
    // Кол-во зон ПГП
    private int _PGPAmount;
    
    /*
     * Стартовый метод
     *
     * Собирает всю информацию о предметах на сцене
     */
    private void Start()
    {
        // Получение кол-ва грязи
        _DirtsAmount = GameObject.Find("Dirts").transform.childCount;
        _PGPAmount = GameObject.Find("PGP Quest").transform.childCount;
    }

    // Квест ведра
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
                manager.Notify_BucketQuestComplete();
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
                manager.Notify_Fall();
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
                manager.Notify_DirtQuestComplete();
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
    
    // Получение и установка статуса квеста грязи
    public bool PGP_Quest_isComplete
    {
        get
        {
            return _PGP_Quest_isComplete;
        }
        set
        {
            _PGP_Quest_isComplete = value;
            if (value)
            {
                manager.Notify_PGP_Quest();
            }
        }
    }
    
    // Получение и установка статуса квеста грязи
    public bool PGP_Zone_Quest_isComplete
    {
        get
        {
            return _PGP_Zone_Quest_isComplete;
        }
        set
        {
            _PGP_Zone_Quest_isComplete = value;
            if (value)
            {
                manager.Notify_PGP_Zone_Quest();
            }
        }
    }

    public int PGPAmount
    {
        get
        {
            return _PGPAmount;
        }
        set
        {
            _PGPAmount = value;
            if (value <= 0)
            {
                PGP_Quest_isComplete = true;
            }
        }
    }
}
