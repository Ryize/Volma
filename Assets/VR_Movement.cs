using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Movement : MonoBehaviour
{
    //public Vector2 moveVector;
    public float speed = 1;
    public Camera head;
    public float andleY;

    // Update is called once per frame
    void Update()
    {
        // float x = transform.position.x + moveVector.x;
        // float y = transform.position.y;
        // float z = transform.position.z + moveVector.y;

        // Vector3 newPosition = new Vector3(x, y, z);

        // transform.position = newPosition;
    }

    public void Move(Vector2 moveVector) {
        float cosY = Mathf.Cos(andleY * Mathf.Deg2Rad);
        float sinY = Mathf.Sin(andleY * Mathf.Deg2Rad);

        float x = transform.position.x + (moveVector.x * cosY + moveVector.y * sinY) * speed * Time.deltaTime;
        float z = transform.position.z + (-moveVector.x * sinY + moveVector.y * cosY) * speed * Time.deltaTime;
        float y = transform.position.y;

        Vector3 newPosition = new Vector3(x, y, z);

        transform.position = newPosition;
    }

    public void SetCameraAngle() {
        andleY = head.transform.eulerAngles.y;
    }
}
