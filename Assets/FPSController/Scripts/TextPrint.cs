using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    public Text MyText;
    public TextMeshPro myText;
    public TextMeshProUGUI my_text_ui;
    void Start()
    {
        
    }
    
    void Update()
    {
        var broom = GameObject.FindGameObjectsWithTag("Item")[2];
        var dirts = GameObject.FindGameObjectsWithTag("Dirt");
        var textTask = GameObject.FindGameObjectWithTag("Task").GetComponent<TMP_Text>();
        if (dirts.Length == 0)
        {
            textTask.text = "Вы справились с первым заданием!";
            return;
        }
        if (broom.GetComponent<TakenPosition>().isTaken)
        {
            textTask.text = "Подойдите к грязи и вытрети её (зажав левую кнопку, и двигая курсором)";;
        }
    }
}
