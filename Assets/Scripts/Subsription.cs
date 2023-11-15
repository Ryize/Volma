using System.Collections.Generic;

public class Subsription : Base
{
    public Item_Manager manager;

    public List<string> subTypes;
    
    // Start is called before the first frame update
    void Start()
    { 
        manager.subscribe(subTypes[1], this);
        
    }
}
