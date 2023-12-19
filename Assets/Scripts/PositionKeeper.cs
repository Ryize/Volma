using Unity.VisualScripting;
using UnityEngine;

public class PositionKeeper : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPosition;
    
    void Start()
    {
        if (defaultPosition.IsUnityNull())
        {
            defaultPosition = new Vector3(0, 1, 0);
        }
        
        InvokeRepeating("KeepItem", 0, 1);
    }

    private void KeepItem()
    {
        if (transform.position.x > 3.5f || transform.position.x < -3.5f || 
            transform.position.y > 4f || transform.position.y < -1f || 
            transform.position.z > 2f || transform.position.z < -2f
           )
        {
            transform.position = defaultPosition;
            
            if (transform.GetComponent<Rigidbody>())
            {
                transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
