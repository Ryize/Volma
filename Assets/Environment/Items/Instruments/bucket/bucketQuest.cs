using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bucketQuest : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject arm; // рука
    void Update()
    {
        if (arm.transform.childCount == 0)
            return;
        
        // получение объекта из руки
        GameObject obj = arm.transform.GetChild(0).GameObject();
        
        // проверка на тэг ведра без всего
        if (obj.tag.ToLower().Contains("basket_1"))
        {
            if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E))
            {
                arm.GetComponent<TakeItem>().Drop();
                obj.transform.position = new Vector3(7, 1, 99999);
                GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(7f, 1f, -2.852f);
                GameObject.FindGameObjectWithTag("tapHandle").transform.Rotate(new Vector3(0f, 0f, 90f));
                // GameObject.FindGameObjectWithTag("tapHandle").transform.position = new Vector3(0f, 2.595592f, 0f);
            }
        }
        
    }
    private string CameraLook()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3f))
        {
            return hit.transform.tag.ToLower();
        }

        return "";
    }
}