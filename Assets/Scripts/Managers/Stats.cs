using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stats : Repository
{
    private float _cement = 0f;
    private float _water = 0f;
    private string dash = "------------------------------------";

    public TextChange_Script text;
    
    public float cement
    {
        get
        {
            return _cement;
        }
        set
        {
            List<string> statsEl = text.currentText.text.Split(dash).ToList();
            List<string> cementList = statsEl[0].Replace("кг", "").Split(" ").ToList();
            _cement = value;
            text.currentText.text = cementList[0] + " " + _cement + "кг" + "\n" + dash + statsEl[1];
        }
    }
}
