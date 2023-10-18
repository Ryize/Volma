using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using Valve.VR;

public class Test_UI_Quest_Script : MonoBehaviour
{
    public Panel_UI_Script PanelUI;

    private void Update()
    {
        PanelUI.ChangeText("υσι");
    }
}
