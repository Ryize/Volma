using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

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
        if (CameraLook().Contains("faucet") && Input.GetKeyDown(KeyCode.E) && _isOpen &&
            obj.tag.ToLower().Contains("basket_1"))
        {
            arm.GetComponent<TakeItem>().Drop();
            obj.transform.position = new Vector3(7, 1, 99999);
            GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(7f, 0.1f, -2.852f);
            GameObject.FindGameObjectWithTag("basket_2_item").GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeAll;
        }
        if (CameraLook().Contains("basket_2") && Input.GetMouseButtonDown(0) && obj.tag.ToLower().Contains("cement"))
        {
            Vector3 coord = GameObject.FindGameObjectWithTag("basket_2_item").transform.position;
            GameObject.FindGameObjectWithTag("basket_2_item").transform.position = new Vector3(999, 999999, 999999);
            GameObject.FindGameObjectWithTag("basket_3_item").transform.position = new Vector3(coord.x, 0f, coord.z);
            GameObject.FindGameObjectWithTag("basket_3_item").GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeAll;
        }

        if (obj.name.ToLower().Contains("mixer") && Input.GetKey(KeyCode.Mouse0))
        {
            GameObject[] mixerRotate = GameObject.FindGameObjectsWithTag("mixerRotate");
            for (int i = 0; i < mixerRotate.Length; i++)
            {
                mixerRotate[i].GetComponent<Transform>().Rotate(new Vector3(0, 0, 1) * 2 * Time.deltaTime);
            }
        }
        if (CameraLook().Contains("basket_3") && Input.GetMouseButtonDown(0) && obj.name.ToLower().Contains("mixer"))
        {
            Vector3 coord = GameObject.FindGameObjectWithTag("basket_3_item").transform.position;
            GameObject.FindGameObjectWithTag("basket_3_item").transform.position = new Vector3(999, 999999, 999999);
            GameObject.FindGameObjectWithTag("basket_4_item").transform.position = new Vector3(coord.x, 0f, coord.z);
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
