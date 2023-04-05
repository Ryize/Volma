using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Broom_Skript : MonoBehaviour
{
    public Camera playerCamera;
    public float Force = 0.01f;
    public float distance = 10f;
    public GameObject broom;

    private float xForce;
    private float yForce;

    void Update()
    {
        if (Input.GetMouseButton(0) && broom.GetComponent<TakenPosition>().isTaken)
        {
            Sweep();
        }
    }

    void Sweep()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Dirt")
            {
                xForce = Math.Abs(Input.GetAxis("Mouse X")) * Force;
                yForce = Math.Abs(Input.GetAxis("Mouse Y")) * Force;

                hit.transform.GetComponent<Dirt_Script>().dirtCounter -= xForce + yForce;
            }
        }
    }
}
