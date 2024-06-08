using UnityEngine;

public class Bucket_Default_Position_Instrument_Script : MonoBehaviour
{
    /*
     * Телепортирует ведро при выходе за координаты.
     *
     * Если ведро падает, или улетает.
    */
    
    // Изначальная позиция ведра
    public Vector3 defaultPosition;
    
    private void Update()
    {
        /*
         * Следим за координатами и телепортируем ведро, если они выходят за "критические".
         */
        if (transform.position.y < -1 || transform.position.y > 3)
        {
            transform.position = defaultPosition;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
