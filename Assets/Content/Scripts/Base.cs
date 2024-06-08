using UnityEngine;

public class Base : MonoBehaviour
{
    public virtual void Notify(string a)
    {
    }

    public virtual void Notify(string a, bool status = true)
    {
    }
}
