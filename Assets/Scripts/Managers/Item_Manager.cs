using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : Managers
{
    private Dictionary<string, Base> _observers = new Dictionary<string, Base>();
    // public void Notify_Bucket_In_Area_isInArea(bool status)
    // {
    //     foreach (var observer in _observers)
    //     {
    //         if (observer.Value == "bucketInArea")
    //         {
    //             observer.Key.Notify("bucketInArea", status);
    //         }
    //     }
    // }
    
    public void Notify_Fall(bool status)
    {
        foreach (var observer in _observers)
        {
            if (observer.Key == "falled")
            {
                observer.Value.Notify("falled", status);
            }
        }
    }
    
    public void subscribe(Base obj, string subscribeType){
        _observers.Add(subscribeType, obj);
    }
    //
    // public void unsubscribe(Base obj){
    //     _observers.Remove(obj);
    // }
}
