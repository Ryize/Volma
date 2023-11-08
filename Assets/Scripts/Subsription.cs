using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Subsription : Base
{
    public Item_Manager manager;

    public List<string> subTypes;
    
    // Start is called before the first frame update
    void Start()
    { 
        manager.subscribe(this, subTypes[1]);
        
    }
}
