using System;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Item_Repository
{
    /*
     * Класс статистики.
     *
     * Сохраняет статистику по использованию цемента, воды.
    */
    
    // Кол-во цемента в статистике
    private float _cement = 0f;
    
    // Кол-во воды в статистике
    private float _water = 0f;
    
    // Тире в качестве разделителя
    private string dash = "------------------------------------";

    // Доска на которой выводится статистика
    public TextChange_Script text;
    
    // Общее время
    private float _time;

    // Оценка
    private float _rating;

    private List<string> statsText;

    private void Start()
    {
        _cement = 0f;
        _water = 0f;
        _time = 0f;
        _rating = 0f;
        
        statsText = new List<string>();
        statsText.Add("цемент: 0кг\n");
        statsText.Add("вода: 0л\n");
        statsText.Add("время: 00:00\n");
        statsText.Add("оценка: \n");
    }

    public float cement
    {
        get
        {
            return _cement;
        }
        set
        {
            /*
             * При изменении кол-ва цемента сразу меняем и данные в статистике.
             *
             * Цемент должен идти с кг и разделяться тире (переменная dash).
             */
            _cement = (float) Math.Round(value, 2);
            
            SetText(0, _cement);
        }
    }
    
    public float water
    {
        get
        {
            return _water;
        }
        set
        {
            /*
             * При изменении кол-ва воды сразу меняем и данные в статистике.
             *
             * Цемент должен идти с кг и разделяться тире (переменная dash).
             * Вода должна идти с л и разделяться тире (переменная dash).
             */
            _water = (float) Math.Round(value, 2);
            
            SetText(1, _water);
        }
    }

    private void Update()
    {
        Debug.Log(CompletedQuests + " " + _All_Quests_isComplete);
        if (_All_Quests_isComplete)
        {
            return;
        }
        
        _time += Time.deltaTime;
        
        SetText(2, _time);
    }

    private void SetText(int line, float stat)
    {
        switch (line)
        {
            case 0:
                statsText[line] = "цемент: " + stat + "кг\n";
                break;
            case 1:
                statsText[line] = "вода: " + stat + "л\n";
                break;
            case 2:
                float minutes = Mathf.Floor(stat / 60);
                float seconds = Mathf.RoundToInt(stat % 60);
                statsText[line] = "время: " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\n";
                break;
            case 3:
                statsText[line] = "оценка: " + stat + "\n";
                break;
        }

        string currentText = "статистика\n";
        foreach (string text in statsText)
        {
            currentText += dash + "\n";
            currentText += text;
        }

        text.currentText.text = currentText;
    }
}
