using Unity.VisualScripting;
using UnityEngine;

public class PositionKeeper : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Vector3 defaultRotation;

    private Rigidbody rigidbody;

    void Start()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.eulerAngles;

        rigidbody = transform.GetComponent<Rigidbody>();


        InvokeRepeating("KeepItem", 0, 1);
    }

    private void KeepItem()
    {
        if (transform.position.x > 3.5f || transform.position.x < -3.5f || 
            transform.position.y > 4f || transform.position.y < -1f || 
            transform.position.z > 2f || transform.position.z < -2f
           )
        {
            TpToDefaultPosition();
        }
    }

    public void TpToDefaultPosition()
    {
        rigidbody.isKinematic = true;

        transform.position = defaultPosition;
        transform.eulerAngles = defaultRotation;

        rigidbody.isKinematic = false;


        if (rigidbody)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
