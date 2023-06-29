using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    // Установить квест
    public void setTask(String title = "", String description = "")
    {
        // Устанавливает задачу
        var Title = GameObject.FindGameObjectsWithTag("Task")[0].GetComponent<TMP_Text>();
        var Description = GameObject.FindGameObjectsWithTag("Task")[1].GetComponent<TMP_Text>();
        // Если переданные данные не меняют текст, завершаем выполнение метода
        if (title == Title.text && description == Description.text || description == "")
        {
            return;
        }
        changeTitle(title);
        changeDescription(description);
    }
    public void changeTitle(String title)
    {
        // Изменяет название задачи
        var Title = GameObject.FindGameObjectsWithTag("Task")[0].GetComponent<TMP_Text>();
        Title.text = title;
    }

    public void changeDescription(String description)
    {
        // Изменяет описание задачи
        var Description = GameObject.FindGameObjectsWithTag("Task")[1].GetComponent<TMP_Text>();
        if (description == "" || description == Description.text)
        {
            return;
        }

        int PredLengthDescription = Description.text.Length;
        Description.text = description;
        
        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(325, 235 + (Description.text.Length / 15) * 30);
        Vector2 ImagePos = image.rectTransform.position;
        
        // Размер заднего фона автоматически подстраивается под объём переданного текста
        if (PredLengthDescription > Description.text.Length)
        {
            image.rectTransform.position = new Vector2(ImagePos.x, ImagePos.y + ((PredLengthDescription - Description.text.Length) / 15) * 15);
        }
        else
        {
            image.rectTransform.position = new Vector2(ImagePos.x, ImagePos.y - (Description.text.Length / 15) * 15);
        } 
    }
    
    public void changeProgress(String progress)
    {
        // Изменяет строку прогрессал
        var Progress = GameObject.FindGameObjectsWithTag("Task")[2].GetComponent<TMP_Text>();
        Progress.text = progress;
        var Description = GameObject.FindGameObjectsWithTag("Task")[1].GetComponent<TMP_Text>();
        Progress.rectTransform.position = new Vector2(Description.rectTransform.position.x, Description.rectTransform.position.y - 90);
    }

    public void clearProgress()
    {
        // Убирает надпись прогресса
        changeProgress("");
    }
    
    public void changeHint(String hint)
    {
        // Устанавливает подсказку в правом нижнем углу экрана
        var Hint = GameObject.FindGameObjectsWithTag("Task")[3].GetComponent<TMP_Text>();
        Hint.text = hint;
    }
    public void clearHint()
    {
        // Устанавливает дефолтную подсказку
        changeHint("Прочитайте подсказки в углу экрана");
    }
}
