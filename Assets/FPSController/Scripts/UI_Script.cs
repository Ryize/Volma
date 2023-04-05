using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    RaycastHit hit;

    public Image line_h;
    public Image line_v;

    public Color colorOnTarget = new Color32(255, 255, 0, 100);
    public Color colorNotOnTarget = new Color32(255, 255, 255, 100);

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Item")
            {
                //line_v.Color = 0;
                Debug.Log("ishitting");
                line_h.color = colorOnTarget;
                line_v.color = colorOnTarget;
            }
            else
            {
                line_h.color = colorNotOnTarget;
                line_v.color = colorNotOnTarget;
            }
        }
    }
}
