using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class bucketQuest : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject arm; // рука
    public bool isOpen = false;
    void Update()
    {
        if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E) && arm.transform.childCount == 0)
        {
            // Проверка открыт или закрыт кран
            if (!isOpen)
            {
                GameObject.FindGameObjectWithTag("tapHandle").transform.Rotate(new Vector3(0f, 0f, -90f));
                isOpen = true;
                // Если закрыт, открываем (устанавливаем макс. кол-во частиц на 100)
                GameObject.FindGameObjectWithTag("effect").GetComponent<ParticleSystem>().maxParticles = 100;
            }
            else
            {
                GameObject.FindGameObjectWithTag("tapHandle").transform.Rotate(new Vector3(0f, 0f, 90f));
                isOpen = false;
                // Если открыт, закрываем (устанавливаем макс. кол-во частиц на 0)
                GameObject.FindGameObjectWithTag("effect").GetComponent<ParticleSystem>().maxParticles = 0;
            }
        }
        // Если в руке пусто
        if (arm.transform.childCount == 0)
            return;
        
        // Получение объекта из руки
        GameObject obj = arm.transform.GetChild(0).GameObject();
        
        // Проверка на тэг ведра без всего
        if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E) && isOpen &&
            obj.tag.ToLower().Contains("basket_1"))
        {
            arm.GetComponent<TakeItem>().Drop();
            obj.transform.position = new Vector3(7, 1, 99999);
            GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(7.286f, 0, -3.718f);
            GameObject.FindGameObjectWithTag("basket_2_item").GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeAll;
        }
        if (CameraLook().Contains("basket_2") && Input.GetMouseButtonDown(0) && obj.tag.ToLower().Contains("cement"))
        {
            Vector3 coord = GameObject.FindGameObjectWithTag("basket_2_item").transform.position;
            // Симуляция удаления ведра
            GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(999, 999999, 999999);
            // Телепортация ведра на место предыдущего ведра
            GameObject.FindGameObjectWithTag("basket_3_item").transform.position = new Vector3(coord.x, 0f, coord.z);
            // Координаты фризятся, чтобы ведро не проваливалось в пол/стены
            GameObject.FindGameObjectWithTag("basket_3_item").GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeAll;
            obj.GetComponent<AudioSource>().PlayOneShot(obj.GetComponent<AudioSource>().clip);
        }

        if (obj.name.ToLower().Contains("mixer") && Input.GetKey(KeyCode.Mouse0))
        {
            obj.GetComponent<AudioSource>().PlayOneShot(obj.GetComponent<AudioSource>().clip);
            GameObject[] mixerRotate = GameObject.FindGameObjectsWithTag("mixerRotate");
            for (int i = 0; i < mixerRotate.Length; i++)
            {
                // Поворачивание миксера при зажатии ЛКМ
                mixerRotate[i].GetComponent<Transform>().Rotate(new Vector3(0, 0, 1) * 2 * Time.deltaTime);
            }
        }
        if (CameraLook().Contains("basket_3") && Input.GetMouseButtonDown(0) && obj.name.ToLower().Contains("mixer"))
        {
            Vector3 coord = GameObject.FindGameObjectWithTag("basket_3_item").transform.position;
            GameObject.FindGameObjectWithTag("basket_3_item").transform.position = new Vector3(999, 999999, 999999);
            GameObject.FindGameObjectWithTag("basket_4_item").transform.position = new Vector3(coord.x, 0f, coord.z);
            // Координаты фризятся, чтобы ведро не проваливалось в пол/стены
            GameObject.FindGameObjectWithTag("basket_4_item").GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeAll;
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
