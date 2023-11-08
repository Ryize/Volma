using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Base
{
    public GameObject cube;
    public Item_Repository repa;
    
    void Update()
    {
        if (cube.transform.position.y < 1)
        {
            repa.Test_fallStatus = true;
        }
        else
        {
            repa.Test_fallStatus = false;
        }
    }
}
