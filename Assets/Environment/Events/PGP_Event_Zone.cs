using UnityEngine;

public class PGP_Event_Zone : MonoBehaviour
{
    public bool isDone()
    {
        return transform.childCount <= 2;
    }
}
