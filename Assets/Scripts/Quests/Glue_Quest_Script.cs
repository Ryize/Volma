using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue_Quest_Script : MonoBehaviour
{
    private void OnDestroy()
    {
        if (transform.parent.childCount <= 3)
            transform.parent.GetComponent<PGP_Event_Zone>().CompleteQuest();
    }
}
