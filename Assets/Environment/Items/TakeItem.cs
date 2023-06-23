using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentItem;
    bool canToTake = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Take();
        if(Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    void Take()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.distance > 3)
            {
                return;
            }
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Item")
            {
                if (canToTake) 
                    Drop();

                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.GetComponent<TakenPosition>().Take(currentItem);
                canToTake = true;
            }
        }
    }

    void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<TakenPosition>().Drop();
        canToTake = false;
        currentItem = null;
    }
}
