using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class bucketQuest : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject arm; // рука
    private bool _isOpen = false;
    void Update()
    {
        if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E) && arm.transform.childCount == 0)
        {
            if (!_isOpen)
            {
                GameObject.FindGameObjectWithTag("tapHandle").transform.Rotate(new Vector3(0f, 0f, -90f));
                _isOpen = true;
                GameObject.FindGameObjectWithTag("effect").GetComponent<ParticleSystem>().maxParticles = 100;
            }
            else
            {
                GameObject.FindGameObjectWithTag("tapHandle").transform.Rotate(new Vector3(0f, 0f, 90f));
                _isOpen = false;
                GameObject.FindGameObjectWithTag("effect").GetComponent<ParticleSystem>().maxParticles = 0;
            }
        }
        if (arm.transform.childCount == 0)
            return;
        
        // получение объекта из руки
        GameObject obj = arm.transform.GetChild(0).GameObject();
        
        // проверка на тэг ведра без всего
        if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E) && _isOpen && obj.tag.ToLower().Contains("basket_1"))
            {
                arm.GetComponent<TakeItem>().Drop();
                obj.transform.position = new Vector3(7, 1, 99999);
                GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(7f, 2f, -2.852f);
                GameObject.FindGameObjectWithTag("basket_2_item").GetComponent<Rigidbody>().mass = 0;
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
