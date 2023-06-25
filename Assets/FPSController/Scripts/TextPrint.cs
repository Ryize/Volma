using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    // Поставить квест
    public void setTask(String task)
    {
        var textTask = GameObject.FindGameObjectWithTag("Task").GetComponent<TMP_Text>();
        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();

        textTask.text = task;
        image.rectTransform.sizeDelta = new Vector2(175, 45);
        image.rectTransform.position = new Vector2(93, 393);
    }
}
