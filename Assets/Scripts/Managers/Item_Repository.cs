using System;
using System.Collections.Generic;
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
    
    // Список квестов
    public List<GameObject> quests;
    
    // Статус положения ведра
    private bool _Bucket_Quest_isComplete;
    // Статус тестового квеста
    private bool _Test_fallStatus = false;
    // Статус квеста грязи
    private bool _Dirt_Quest_isComplete;
    // Статус квеста грунтовки
    private bool _Primer_Quest_isComplete;
    // Статус квеста ПГП
    private bool _PGP_Quest_isComplete;
    // Статус квеста Пены
    private bool _Foam_Quest_isComplete;
    // Статус всех квестов
    protected bool _All_Quests_isComplete;
    
    // Кол-во грязи
    private int _DirtsAmount;
    // Кол-во зон грунтовки
    private int _PrimerAmount;
    // Кол-во зон ПГП
    private int _PGPAmount;
    // Кол-во зон для пены
    private int _FoamAmount;
    // Кол-во выполненных квестов
    private int _CompletedQuests;
    
    /*
     * Стартовый метод
     *
     * Собирает всю информацию о предметах на сцене
     */
    private void Start()
    {
        if (quests[0]) _DirtsAmount = quests[0].transform.childCount;
        if (quests[1]) _PrimerAmount = quests[1].transform.childCount;
        Debug.Log("_PrimerAmount: " + _PrimerAmount);
        if (quests[2]) _PGPAmount = quests[2].transform.childCount;
        if (quests[3]) _FoamAmount = quests[3].transform.childCount;

        _CompletedQuests = 0;
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
                CompletedQuests++;
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
                CompletedQuests++;
            }
        }
    }
    
    // Получение и установка кол-ва зон грунтовки
    public int PrimerAmount
    {
        get
        {
            return _PrimerAmount;
        }
        set
        {
            _PrimerAmount = value;
            if (value <= 0)
            {
                Primer_Quest_isComplete = true;
            }
        }
    }

    public bool Primer_Quest_isComplete
    {
        get
        {
            return _Primer_Quest_isComplete;
        }
        set
        {
            _Primer_Quest_isComplete = value;
            if (value)
            {
                manager.Notify_Primer_Quest();
                CompletedQuests++;
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
            Debug.Log("[Item_Repository] PGPAmount value: " + value);
            
            if (value == _PGPAmount - 1)
            {
                manager.Notify_PGP_Zone_Quest();
            }
            
            _PGPAmount = value;
            
            if (value <= 0)
            {
                PGP_Quest_isComplete = true;
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
                quests[3].gameObject.SetActive(true);
                manager.Notify_PGP_Quest();
                CompletedQuests++;
            }
        }
    }
    
    // Получение и установка кол-ва зон грунтовки
    public int FoamAmount
    {
        get
        {
            return _FoamAmount;
        }
        set
        {
            _FoamAmount = value;
            if (value <= 0)
            {
                Foam_Quest_isComplete = true;
            }
        }
    }

    public bool Foam_Quest_isComplete
    {
        get
        {
            return _Foam_Quest_isComplete;
        }
        set
        {
            _Foam_Quest_isComplete = value;
            if (value)
            {
                manager.Notify_Foam_Quest();
                CompletedQuests++;
            }
        }
    }

    public int CompletedQuests
    {
        get
        {
            return _CompletedQuests;
        }
        set
        {
            _CompletedQuests = value;
            // quests.Count не работает, хз почему
            if (value >= 5)
            {
                _All_Quests_isComplete = true;
            }
        }
    }
}
