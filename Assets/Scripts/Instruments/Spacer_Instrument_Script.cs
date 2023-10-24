using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacer_Instrument_Script : PGP_Event_Zone
{
    public bool done = false;

    public bool isDone()
    {
        return done;
    }

    public void setDone() {
        done = true;
    }
}
