using System.Collections;
using System.Collections.Generic;
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
        if (transform.childCount > pgpCounter+1 && transform.GetChild(pgpCounter).gameObject.GetComponent<PGP_Event_Zone>().GetQuestStatus()) {
            transform.GetChild(++pgpCounter).gameObject.SetActive(true);
        }
    }
}
