using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Primer_Script : MonoBehaviour
{
    public Camera playerCamera;
    public float distance = 3f;
    public GameObject primer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && primer.GetComponent<TakenPosition>().isTaken)
        {
            Pour();
        }
    }

    // Налить грунтовку в кюветку
    void Pour()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distance))
        {
            // если дистанция больше 3
            if (hit.distance > 3)
            {
                return;
            }
            // если взаимодействие происходит с кюветкой
            if(hit.transform.tag.ToLower().Contains("cuvette"))
            {
                hit.transform.Find("PrimerPaint").GameObject().SetActive(true);
            }
        }
    }
}
