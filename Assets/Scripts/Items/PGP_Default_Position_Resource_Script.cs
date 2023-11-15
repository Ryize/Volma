using UnityEngine;

public class PGP_Default_Position_Resource_Script : MonoBehaviour
{
    public Vector3 defaultPosition;

    public void setDefaultPosition() {
        transform.position = defaultPosition;
    }
}
