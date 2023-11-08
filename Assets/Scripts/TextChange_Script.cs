using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextChange_Script : MonoBehaviour
{
    public string newText;
    public TextMeshProUGUI currentText;
    private List<string> Quests = new List<string>();
    private int currentQuest = 0;


    private void Start()
    {
        int k = 0;
        for (int i = 0; i < 5; i++)
        {
            Quests.Add(k.ToString());
            k++;
            Debug.Log(Quests[i]); 
        }
        Debug.Log(Quests);   
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
}
