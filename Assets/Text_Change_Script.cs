using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text_Change_Script : MonoBehaviour
{
    private Text newText;
    public Button button;
    public Text text;
    void Start()
    {
        newText.text = "text";
    }

    public void ChangeIt()
    {
        text.text = newText.text;
    }
}
