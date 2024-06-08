using UnityEngine;

public class Zone_Quest_Script : MonoBehaviour
{
    public GameObject glue;

    private void OnDestroy()
    {
        glue.SetActive(true);
    }
}
