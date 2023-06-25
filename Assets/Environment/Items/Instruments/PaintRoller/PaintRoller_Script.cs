using Unity.VisualScripting;
using UnityEngine;
using System;

public class PaintRoller_Script : MonoBehaviour
{
    public Camera playerCamera;
    public float Force = 0.01f;
    public float distance = 10f;
    public GameObject PaintRoller;
    public float paintFlowTracker = 0; 
    
    private float xForce;
    private float yForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && PaintRoller.GetComponent<TakenPosition>().isTaken)
        {
            Dip();
        }
    }

    // Налить грунтовку в кюветку
    void Dip()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distance))
        {
            // если дистанция больше 3
            if (hit.distance > 3)
            {
                return;
            }
            xForce = Math.Abs(Input.GetAxis("Mouse X")) * Force;
            yForce = Math.Abs(Input.GetAxis("Mouse Y")) * Force;
            // если взаимодействие происходит с кюветкой
            if(hit.transform.tag.ToLower().Contains("cuvette") &&
               hit.transform.Find("PrimerPaint").GameObject().activeSelf)
            {
                paintFlowTracker += (xForce + yForce) * 10;
            }
            else
            {
                paintFlowTracker -= xForce + yForce;
            }
            paintFlowTracker = Mathf.Clamp(paintFlowTracker, 0, 100);
        }
    }
}
