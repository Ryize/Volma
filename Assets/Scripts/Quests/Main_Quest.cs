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
    //public Item_Repository repository;
        
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
            manager.Subscribe(type, this);
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
    public override void Notify(string questType)
    {
        QuestComplete(questType);
    }
    
    public void QuestComplete(string quest)
    {
        Debug.Log("[Main_Quest] QuestComplete: " + quest);

        switch (quest)
        {
            // Квест грязи
            case "dirt_completed":
                desk.QuestCompleted(0);
                break;
            // Квест ведра
            case "bucket_completed":
                desk.QuestCompleted(1);
                break;
            // Квест грунтовки
            case "primer_completed":
                desk.QuestCompleted(2);
                break;
            // Квест грунтовки
            case "pgp_completed":
                desk.QuestCompleted(3);
                break;
            // Обработка неизвестного квеста
            default:
                Debug.Log("Неизвестный квест");
                break;
        }
        
    }
}
