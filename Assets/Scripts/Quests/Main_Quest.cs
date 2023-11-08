using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Quest : Base
{
    /*
     * Класс квестов
     *
     * Реализует логику работы квестов.
     */

    // Квест грязи
    public Dirt_Quest_Script DirtQuestScript;
    
    // Репозиторий предеметов
    public Item_Repository repa;
        
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
        QuestComplete();
    }
    
    public void QuestComplete()
    {
        Debug.Log("Main_Quest: QuestComplete");
    }
}
