using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        Quests.Add("Подготовка основания:\n\t" +
                   "1.Взять метлу\n\t" +
                   "2.Подойти к загрязненному месту\n\t" +
                   "3.Очистить поверхность\n");
        Quests.Add("3амешивание цементно-песчаного раствора:\t\n\t" +
                   "1.Взять ведро\n\t" +
                   "2.Набрать воды\n\t" +
                   "3.Добавить клей \"Волма-монтаж\" в пропорции 0,5-0,57 л воды/кг сухой смеси\n\t" +
                   "4.Перемешать до однородной массы с помощью строительного миксера\n");
        Quests.Add("Установка ПГП плит:\n\t" +
                   "1.Нанести приготовленный раствор на место установки плиты(пол, стена) с помощью шпателя\n\t" +
                   "2.Взять плиту\n\t" +
                   "3.Установить плиту\n\t" +
                   "4.Проверить ровность установки плиты уровнем\n\t" +
                   "5.Нанести клей на установленную плиту(сверху, ребро)\n\t" +
                   "6.Установить следующую плиту\n\t" +
                   "7.Повторить предыдущие шаги \n\t"+
                   "8.При создании дверного проёма монтировать распорку\n\t"+
                   "9.После возведения залить место стыка стены с потолком монтажной пеной\n");
        currentText.text = Quests[currentQuest];
    }
    public void ChangeTextNext()
    {
        if (currentQuest <2)
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

    public void QuestCompleted()
    {
        currentText.color = Color.green;
    }
}
