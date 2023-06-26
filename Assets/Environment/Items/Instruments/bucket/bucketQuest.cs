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
                Destroy(obj);
                GameObject gm = GameObject.FindGameObjectWithTag("basket_2_item").GameObject();
                gm.transform.parent = arm.transform;
                gm.transform.position = arm.transform.position;
                gm.GetComponent<Rigidbody>().isKinematic = true;
                gm.GetComponent<TakenPosition>().Take(gm);
                arm.GetComponent<TakeItem>().canToTake = false;
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
