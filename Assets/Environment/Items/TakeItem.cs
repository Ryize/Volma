using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject camera;
    public float distance = 3f;
    public GameObject currentItem;
    public bool canToTake = false;
    
    void Update()
    {
        // На E - взять, на Q - бросить
        if (Input.GetKeyDown(KeyCode.E))
            Take();
        if(Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    public void Take()
    {
        // Позволяет взять предмет
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag.ToLower().Contains("item"))
            {
                // Если предмет уже взят - бросить текущий
                if (canToTake) 
                    Drop();
                
                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.layer = 6;
                currentItem.GetComponent<TakenPosition>().Take(currentItem);
                canToTake = true;
                currentItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }

    public void Drop()
    {
        // Позволяет бросить предмеи
        currentItem.transform.parent = null;
        currentItem.layer = 0;
        // Нужно для падения под 0 углом, чтобы предметы падали ровно
        if (currentItem.tag == "basket_1_item")
        {
            // У ведра другие базовые координаты
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
