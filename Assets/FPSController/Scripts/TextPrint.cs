using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    public Text MyText;
    public TextMeshPro myText;
    public TextMeshProUGUI my_text_ui;
    void Update()
    {
        faucetText()
    }
    bool broomText()
    {
        var broom = GameObject.FindGameObjectsWithTag("Item")[2];
        var dirts = GameObject.FindGameObjectsWithTag("Dirt");
        var textTask = GameObject.FindGameObjectWithTag("Task").GetComponent<TMP_Text>();
        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
        if (dirts.Length == 0)
        {
            textTask.text = "Вы справились с первым заданием!";
            image.rectTransform.sizeDelta = new Vector2(175, 65);
            image.rectTransform.position = new Vector2(93, 383);
            return true;
        }
        else if (broom.GetComponent<TakenPosition>().isTaken)
        {
            textTask.text = "Подойдите к грязи и вытрети её (зажав левую кнопку, и двигая курсором)";
            image.rectTransform.sizeDelta = new Vector2(175, 125);
            image.rectTransform.position = new Vector2(93, 353);
        }
        else
        {
            textTask.text = "Возьмите метлу";
            image.rectTransform.sizeDelta = new Vector2(175, 45);
            image.rectTransform.position = new Vector2(93, 393);
        }

        return false;
    }

    bool faucetText()
    {
        /*
         * Проверка на исполнение предыдущего квеста.
         */
        if (broomText() == false)
        {
            return false;
        }
        var textTask = GameObject.FindGameObjectWithTag("Task").GetComponent<TMP_Text>();
        var image = GameObject.FindGameObjectWithTag("menuImage").GetComponent<Image>();
        textTask.text = "Возьмите ведро!";
        image.rectTransform.sizeDelta = new Vector2(175, 65);
        image.rectTransform.position = new Vector2(93, 383);
        return true;
    }
}
