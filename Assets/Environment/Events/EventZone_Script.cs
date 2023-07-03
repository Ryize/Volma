using UnityEngine;

public class EventZone_Script : MonoBehaviour
{
    public float EventZoneCounter = 10;
    public GameObject glue;

    private void OnDestroy()
    {
        glue.SetActive(true);
    }
}
