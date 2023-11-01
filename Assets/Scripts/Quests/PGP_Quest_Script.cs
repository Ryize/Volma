using UnityEngine;

public class PGP_Quest_Script : MonoBehaviour
{
    private int pgpCounter;

    private void Start()
    {
        pgpCounter = 0;
    }

    private void Update()
    {
        if (transform.childCount > pgpCounter+1 && transform.GetChild(pgpCounter).gameObject.GetComponent<PGP_Zone_Quest_Script>().GetQuestStatus()) {
            transform.GetChild(++pgpCounter).gameObject.SetActive(true);
        }
    }
}
