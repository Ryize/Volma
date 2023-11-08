using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextChange_Script : MonoBehaviour
{
    // Класс реализующий смену страниц текста на панели
    //
    // Используется ТОЛЬКО для панели с квестами
    
    public TMP_Text currentText;
    private List<string> Quests = new List<string>();
    private int currentQuest = 0;


    private void Start()
    {
        Quests.Add("Подготовка основания:1.Взять метлу (клавиша E/ЛКМ) 2.Подойти к загрязненному месту 3.Очистить поверхность (зажать ЛКМ на n секунд) 4.Вернуть метлу на место(обязательно)");
        Quests.Add("");
        Quests.Add("");
    }
    public void ChangeTextNext()
    {
        if (currentQuest <= 3)
        {
            currentQuest++;
            currentText.text = Quests[currentQuest];
        }
    }
    public void ChangeTextPrevious()
    {
        if(currentQuest!=0)
        {
            currentQuest--;
            currentText.text = Quests[currentQuest];
        }
    }
}
