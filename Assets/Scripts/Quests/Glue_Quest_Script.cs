using UnityEngine;

public class Glue_Quest_Script : MonoBehaviour
{
    private void OnDestroy()
    {
        if (transform.parent.childCount <= 3)
            transform.parent.GetComponent<PGP_Zone_Quest_Script>().CompleteQuest();
    }
}
