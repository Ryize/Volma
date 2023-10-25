using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextChange_Script : MonoBehaviour
{
    public string newText;
    public TextMeshProUGUI currentText;

   public void ChangeText()
    {
        currentText.text = newText;
    }
}
