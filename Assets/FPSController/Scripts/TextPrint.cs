using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Класс для управления отображением текстовых элементов на экране.
/// </summary>
public class TextPrint : MonoBehaviour
{
    private TMP_Text titleText; // Текстовый элемент для заголовка задачи
    private TMP_Text descriptionText; // Текстовый элемент для описания задачи
    private TMP_Text progressText; // Текстовый элемент для отображения прогресса задачи
    private TMP_Text hintText; // Текстовый элемент для отображения подсказки
    private Image menuImage; // Изображение заднего фона

    private void Awake()
    {
        // Поиск и получение ссылок на текстовые элементы и изображение в сцене
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag("Task");
        if (taskObjects.Length >= 4)
        {
            titleText = taskObjects[0].GetComponent<TMP_Text>();
            descriptionText = taskObjects[1].GetComponent<TMP_Text>();
            progressText = taskObjects[2].GetComponent<TMP_Text>();
            hintText = taskObjects[3].GetComponent<TMP_Text>();
        }
        menuImage = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
    }

    /// <summary>
    /// Устанавливает задачу с указанным заголовком и описанием.
    /// </summary>
    /// <param name="title">Заголовок задачи.</param>
    /// <param name="description">Описание задачи.</param>
    public void SetTask(string title = "", string description = "")
    {
        if (title == titleText.text && description == descriptionText.text || description == "")
        {
            return;
        }
        ChangeTitle(title);
        ChangeDescription(description);
    }

    /// <summary>
    /// Изменяет заголовок задачи.
    /// </summary>
    /// <param name="title">Новый заголовок задачи.</param>
    public void ChangeTitle(string title)
    {
        titleText.text = title;
    }

    /// <summary>
    /// Изменяет описание задачи.
    /// </summary>
    /// <param name="description">Новое описание задачи.</param>
    public void ChangeDescription(string description)
    {
        if (description == "" || description == descriptionText.text)
        {
            return;
        }

        int previousDescriptionLength = descriptionText.text.Length;
        descriptionText.text = description;

        menuImage.rectTransform.sizeDelta = new Vector2(325, 235 + (descriptionText.text.Length / 15) * 30);
        Vector2 imagePos = menuImage.rectTransform.position;

        if (previousDescriptionLength > descriptionText.text.Length)
        {
            menuImage.rectTransform.position = new Vector2(imagePos.x, imagePos.y + ((previousDescriptionLength - descriptionText.text.Length) / 15) * 15);
        }
        else
        {
            menuImage.rectTransform.position = new Vector2(imagePos.x, imagePos.y - (descriptionText.text.Length / 15) * 15);
        }
    }

    /// <summary>
    /// Изменяет строку прогресса задачи.
    /// </summary>
    /// <param name="progress">Строка прогресса.</param>
    public void ChangeProgress(string progress)
    {
        progressText.text = progress;
        progressText.rectTransform.position = new Vector2(descriptionText.rectTransform.position.x, descriptionText.rectTransform.position.y - 90);
    }

    /// <summary>
    /// Убирает строку прогресса задачи.
    /// </summary>
    public void ClearProgress()
    {
        ChangeProgress("");
    }

    /// <summary>
    /// Устанавливает подсказку в правом нижнем углу экрана.
    /// </summary>
    /// <param name="hint">Подсказка.</param>
    public void ChangeHint(string hint)
    {
        hintText.text = hint;
    }

    /// <summary>
    /// Устанавливает дефолтную подсказку.
    /// </summary>
    public void ClearHint()
    {
        ChangeHint("Прочитайте задание в углу экрана");
    }

    /// <summary>
    /// Убирает подсказки и строку прогресса задачи.
    /// </summary>
    public void ClearAuxiliaryLabels()
    {
        ClearHint();
        ClearProgress();
    }
}
