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
        Debug.Log("!!! ");
        Debug.Log(description);
        Debug.Log(Description.text);
        if (title == Title.text && description == Description.text || description == "")
        {
            return;
        }
        if (title != "")
        {
            Title.text = title;
        }

        int PredLengthDescription = Description.text.Length;

        if (description != "")
        {
            Description.text = description;
        }

        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(325, 250 + (Description.text.Length / 15) * 30);
        Vector2 ImagePos = image.rectTransform.position;
        image.rectTransform.position = new Vector2(ImagePos.x, ImagePos.y - (Description.text.Length / 15) * 15);

            }
}
