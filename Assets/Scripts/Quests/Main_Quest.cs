using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Quest : Quest
{
    /*
     * Класс квестов
     *
     * Реализует логику работы квестов.
     */
    
    // Репозиторий предеметов
    public Item_Repository repa;
        
    // Менеджер объектов
    public Item_Manager manager;

    // Тип событий, который отслеживается 
    public List<string> subTypes;
    
    // Доска с квестами
    public TextChange_Script desk;
    
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
     * Уведомление о завершении квеста
     *
     * Args:
     *  questType: string (тип события)
     *  status: bool (состояние кубика)
     */
    public override void Notify(string questType, bool status)
    {
        // Квест грязи
        if (questType == "dirt_completed")
        {
            QuestComplete();
        }
    }
    
    public void QuestComplete()
    {
        Debug.Log("Main_Quest: QuestComplete");
        desk.QuestCompleted();
    }
}
