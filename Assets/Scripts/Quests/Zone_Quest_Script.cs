using UnityEngine;

public class Zone_Quest_Script : MonoBehaviour
{
    public GameObject glue;

    private void OnDestroy()
    {
        glue.SetActive(true);

        if (transform.parent.childCount == 5) {
            transform.parent.GetChild(4).gameObject.SetActive(true);
        }
    }
}
