using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    // Поставить квест
    public void setTask(String title = "", String description = "")
    {
        var Title = GameObject.FindGameObjectsWithTag("Task")[0].GetComponent<TMP_Text>();
        var Description = GameObject.FindGameObjectsWithTag("Task")[1].GetComponent<TMP_Text>();
        if (title == Title.text && description == Description.text || description == "")
        {
            return;
        }
        changeTitle(title);
        changeDescription(description);
    }
    public void changeTitle(String title)
    {
        var Title = GameObject.FindGameObjectsWithTag("Task")[0].GetComponent<TMP_Text>();
        Title.text = title;
    }

    public void changeDescription(String description)
    {
        var Description = GameObject.FindGameObjectsWithTag("Task")[1].GetComponent<TMP_Text>();
        
        int PredLengthDescription = Description.text.Length;
        Description.text = description;
        
        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(325, 250 + (Description.text.Length / 15) * 30);
        Vector2 ImagePos = image.rectTransform.position;
        if (PredLengthDescription > Description.text.Length)
        {
            image.rectTransform.position = new Vector2(ImagePos.x, ImagePos.y + ((PredLengthDescription - Description.text.Length) / 15) * 15);
        }
        else
        {
            image.rectTransform.position = new Vector2(ImagePos.x, ImagePos.y - (Description.text.Length / 15) * 15);
        } 
    }
}
