using UnityEngine;

public class Bucket_Default_Position_Instrument_Script : MonoBehaviour
{
    public Vector3 defaultPosition;
    
    private void Update()
    {
        if (transform.position.y < -1 || transform.position.y > 3)
        {
            transform.position = defaultPosition;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
