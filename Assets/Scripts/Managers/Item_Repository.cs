using UnityEngine;

public class Item_Repository : Repository
{
    private bool _Bucket_In_Area_isInArea;
    private bool _Test_fallStatus = false;
    public Item_Manager manager; 
    

    public bool Bucket_In_Area_isInArea
    {
        get
        {
            return _Bucket_In_Area_isInArea;
        }
        set
        {
            _Bucket_In_Area_isInArea = value;

            if (value)
            {
                // manager.Notify_Bucket_In_Area_isInArea(value);
            }
        }
    }
    
    public bool Test_fallStatus
    {
        get
        {
            return _Test_fallStatus;
        }
        set
        {
            _Test_fallStatus = value;
            if (value)
            {
                manager.Notify_Fall(value);
            }
        }
    }
}
