using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    public GameObject currentItem;
    public bool canToTake = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Take();
        if(Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    public void Take()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.distance > 3)
            {
                return;
            }
            if(hit.transform.tag.ToLower().Contains("item"))
            {
                if (canToTake) 
                    Drop();
                
                currentItem = hit.transform.gameObject;
                
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.layer = 6;
                currentItem.GetComponent<TakenPosition>().Take(currentItem);
                canToTake = true;
            }
        }
    }

    public void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.layer = 0;
        if (currentItem.tag == "basket_1_item")
        {
            currentItem.transform.eulerAngles = new Vector3(-90, 0, 0);
        }
        else
        {
            currentItem.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<TakenPosition>().Drop();
        canToTake = false;
        currentItem = null;
    }
}
