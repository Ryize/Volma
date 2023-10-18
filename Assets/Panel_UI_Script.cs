using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Panel_UI_Script : MonoBehaviour
{
    public Text tmp;
    //public GameObject PanelText;
    //public GameObject manager;

    public void ChangeText(string newText)
    {
        tmp.text = newText;
    }
}
