using UnityEngine;

/// <summary>
/// Класс для взаимодействия с предметами в игре.
/// </summary>
public class TakeItem : MonoBehaviour
{
    public GameObject camera;
    public float distance = 3f;
    public GameObject currentItem;
    public bool canTake = false;

    private void Update()
    {
        // На E - взять, на Q - бросить
        if (Input.GetKeyDown(KeyCode.E))
            Take();
        if (Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    /// <summary>
    /// Взять предмет.
    /// </summary>
    public void Take()
    {
        // Позволяет взять предмет
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag.ToLower().Contains("item"))
            {
                // Если предмет уже взят - бросить текущий
                if (canTake)
                    Drop();
                
                camera.GetComponent<AudioSource>().PlayOneShot(camera.GetComponent<AudioSource>().clip);

                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.layer = 6;
                currentItem.GetComponent<TakenPosition>().Take(currentItem);
                canTake = true;
                currentItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }

    /// <summary>
    /// Бросить предмет.
    /// </summary>
    public void Drop()
    {
        // Позволяет бросить предмет
        currentItem.transform.parent = null;
        currentItem.layer = 0;

        // Нужно для падения под 0 углом, чтобы предметы падали ровно
        if (currentItem.CompareTag("basket_1_item"))
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
        canTake = false;
        currentItem = null;
    }
}
