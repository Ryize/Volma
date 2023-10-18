using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pgp_DefaultPosition : MonoBehaviour
{
    public Vector3 defaultPosition;

    public void setDefaultPosition() {
        transform.position = defaultPosition;
    }
}
