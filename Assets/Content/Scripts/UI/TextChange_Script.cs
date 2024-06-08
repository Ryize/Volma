using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange_Script : MonoBehaviour
{
    /* Класс реализующий смену страниц текста на панели  
     * Используется ТОЛЬКО для панели с квестами
    */
    
    // Звук выполнения квеста
    protected AudioSource _questCompleteSound;
    
    // Переменная с текущим текстом на доске
    public TMP_Text currentText;
    
    // Список со всеми квестами
    private List<string> _quests = new List<string>();
    
    // Список завершённых квестов
    private List<bool> _completedQuests = new List<bool>();
    
    // Индекс текущего квеста для вывода
    private int currentQuest = 0;

    private static readonly Color colorQuestCompleted = Color.green;
    private static readonly Color colorQuestIncompleted = Color.white;


    /* Метод с стартовыми данными
     *
     * Задаёт сами квесты
     */
    private void Start()
    {
        // Первый квест
        AddQuestText("Подготовка основания:\n\t" +
                 "1.Взять метлу\n\t" +
                 "2.Подойти к загрязненному месту\n\t" +
                 "3.Очистить поверхность\n");
        
        // Второй квест
        AddQuestText("3амешивание цементно-песчаного раствора:\t\n\t" +
                 "1.Взять ведро\n\t" +
                 "2.Набрать воды\n\t" +
                 "3.Добавить клей \"Волма-монтаж\" в пропорции 0,5-0,57 л воды/кг сухой смеси\n\t" +
                 "4.Перемешать до однородной массы с помощью строительного миксера\n");
        
        // Третий квест
        AddQuestText("Грунтовка поверхности:\n\t" +
                 "1.Налить грунтовкку в кюветку\n\t" +
                 "2.Обмакнуть валик в кюветку\n\t" +
                 "3.Нанести грунтовку на помеченую на поверхность\n");
        
        // Четвертый квест
        AddQuestText("Установка ПГП плит:\n\t" +
                 "1.Нанести приготовленный раствор на место установки плиты(пол, стена) с помощью шпателя\n\t" +
                 "2.Взять плиту\n\t" +
                 "3.Установить плиту\n\t" +
                 "4.Проверить ровность установки плиты уровнем\n\t" +
                 "5.Нанести клей на установленную плиту(сверху, ребро)\n\t" +
                 "6.Установить следующую плиту\n\t" +
                 "7.Повторить предыдущие шаги \n\t"+
                 "8.При создании дверного проёма монтировать распорку\n");
        
        // Пятый квест
        AddQuestText("Установка ПГП плит:\n\t" +
                 "9.После возведения залить место стыка стены с потолком монтажной пеной\n");

        _questCompleteSound = GetComponent<AudioSource>();
    }

    /* Метод для добавления текста квестов на панель
     *
     * Добавляет текст со статусом на панель
     * args:
     *  questText (string): текст квеста
     *  status (bool): статус квеста (false по умолчанию)
     */
    protected void AddQuestText(string questText, bool status = false)
    {
        _quests.Add(questText);
        _completedQuests.Add(status);
    }
    
    private void ChangeText(int direction)
    {
        // Напрвеление в котором меняем квест
        currentQuest  = Mathf.Clamp(currentQuest + direction, 0, _completedQuests.Count-1) ;
        
        // Меняем текст 
        currentText.text = _quests[currentQuest];

        // Меняем цвет текста в зависимости от выполнения квеста
        currentText.color = _completedQuests[currentQuest] ? colorQuestCompleted : colorQuestIncompleted;
    }
    
    public void ChangeTextNext()
    {
        ChangeText(1);
    }
    public void ChangeTextPrevious()
    {
        ChangeText(-1);
    }

    /* Метод выполнения квеста
     *
     * Окрашивает текст выполненного квеста в зеленный цвет и проигрывает звук
     * args:
     *  questNumber (int): номер выполненного квеста 
     */
    public void QuestCompleted(int questNumber)
    {
        if (questNumber < 0 || questNumber >= _completedQuests.Count)
        {
            return;
        }
        
        _completedQuests[questNumber] = true;

        if (questNumber == currentQuest)
        {
            currentText.color = colorQuestCompleted;
        }
        
        _questCompleteSound.Play();
    }
}
