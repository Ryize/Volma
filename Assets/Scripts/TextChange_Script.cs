using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class TextChange_Script : Base
{
    // Класс реализующий смену страниц текста на панели
    //
    // Используется ТОЛЬКО для панели с квестами
    
    public TMP_Text currentText;
    private List<string> Quests = new List<string>();
    private int currentQuest = 0;


    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Quests.Add(i.ToString());
            Debug.Log("TextChange_Script Quests[i]: " + Quests[i]); 
        }
        Quests.Add("Если вернуться к нашей шкале ценностей, то мы должны сказать: в Я не только самое глубокое, но и самое высокое может быть бессознательным.\n\nТолкование сновидений есть дорога в царские чертоги к по\u00adзнанию бессознательного, самое определенное основание психоанализа и та область, в которой всякий исследователь приобретает свою убежденность и свое образование.\n\nМы выработали себе понятие о либидо, как о меняющей\u00adся ко\u00adличественной силе, которая может измерять все про\u00adцессы и превращения в области сексуального возбуждения. Это либидо мы отличаем от энергии, которую следует положить в основу душевных процессов, в отношении ее особого проис\u00adхож\u00adдения, и этим приписываем ей также особый качествен\u00adный характер.\n\nTo, что мы называем “характером” человека, создано в зна\u00adчительной степени из материала сексуальных возбужде\u00adний и составляется из фиксированных с детства влечений, приоб\u00adре\u00adтен\u00adных благодаря сублимированию, и из таких кон\u00adструкций, которые имеют своим назначением энергичное по\u00adдавление нер\u00adвозных, признанных недопустимыми душев\u00adных движе\u00adний.");
        Quests.Add("лвапщзршвщшаорщвзшаорваопрвоащпр");
        Quests.Add("вапзщрлухероукшщеорокшщоукешрщукшеро");
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
        //ChangeTextNext();
    }
}
