using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange_Script : Base
{
    public string newText;
    public TextMeshProUGUI currentText;
    private List<string> Quests = new List<string>();
    private int currentQuest = 0;


    private void Start()
    {
        
        
        for (int i = 0; i < 5; i++)
        {
            Quests.Add(i.ToString());
            Debug.Log("TextChange_Script Quests[i]: " + Quests[i]); 
        }
    }
    public void ChangeTextNext()
    {
        currentQuest++;
        currentText.text = Quests[currentQuest];
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
