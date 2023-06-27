using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PaintRoller_Script : MonoBehaviour
{
    public Camera playerCamera;
    public float Force = 0.01f;
    public float distance = 3f;
    public GameObject PaintRoller;
    public float paintFlowTracker = 0;
    public GameObject PrimerLine;
    
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
            xForce = Math.Abs(Input.GetAxis("Mouse X")) * Force;
            yForce = Math.Abs(Input.GetAxis("Mouse Y")) * Force;
            float force = xForce + yForce; 
            // если взаимодействие происходит с кюветкой
            if(hit.transform.tag.ToLower().Contains("cuvette") &&
               hit.transform.Find("PrimerPaint").GameObject().activeSelf)
            {
                paintFlowTracker += force * 10;
            }
            else
            {
                if (hit.transform.tag.Contains("item") || paintFlowTracker < 0.1)
                    return;
                paintFlowTracker -= force;

                if (hit.transform.name.Contains("EventZone"))
                {
                    hit.transform.GetComponent<EventZone_Script>().EventZoneCounter += force * 10;
                    
                    if (hit.transform.GetComponent<EventZone_Script>().EventZoneCounter > 100)
                    {
                        
                        Vector3 position = hit.transform.position;
                        //position = new Vector3(position.x, position.y - 0.01f, position.z);
                        PrimerLine.transform.position = position;
                        PrimerLine.transform.eulerAngles = hit.transform.eulerAngles;
                        Instantiate(PrimerLine); // спавн грунтовки на поверхности

                        Destroy(hit.transform.GameObject()); // Убараем квестовую зону
                    }
                }

                /*Instantiate(PrimerPaint);
                PrimerPaint.rectTransform.position = hit.point;
                PrimerPaint.transform.eulerAngles = transform.eulerAngles;
                //float z = (((int) transform.eulerAngles.z) / 90 + 1) * 90;
                //float x = (((int) transform.eulerAngles.x) / 90 + 1) * 90;
                //float y = (((int) transform.eulerAngles.y) / 90 + 1) * 90;
                //PrimerPaint.transform.eulerAngles = new Vector3(x, y, 0);
                
                /*if (hit.transform.name.Contains("wall1") || hit.transform.name.Contains("wall4"))
                    PrimerPaint.transform.eulerAngles = new Vector3(0, 0, 0);
                if (hit.transform.name.Contains("wall2") || hit.transform.name.Contains("wall3"))
                    PrimerPaint.transform.eulerAngles = new Vector3(0, 90, 0);
                if (hit.transform.name.Contains("floor"))
                    PrimerPaint.transform.eulerAngles = new Vector3(90, 0, 0);
                if (hit.transform.name.Contains("ceiling"))
                    PrimerPaint.transform.eulerAngles = new Vector3(90, 0, 0);#1#
                
                PrimerPaint.transform.SetSiblingIndex(hit.transform.GetSiblingIndex() + 1);*/
            }
            paintFlowTracker = Mathf.Clamp(paintFlowTracker, 0, 100);
        }
    }
}
