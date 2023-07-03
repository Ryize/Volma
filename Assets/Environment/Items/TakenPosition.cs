using UnityEngine;

public class TakenPosition : MonoBehaviour
{
    public Vector3 Position = new Vector3(0, 0, 0);
    public Vector3 EulerAngles = new Vector3(180f, 0f, 0f);

    public bool isTaken = false;

    public void Take(GameObject item)
    {
        item.transform.localPosition = Position;
        item.transform.localEulerAngles = EulerAngles;
        isTaken = true;
    }

    public void Drop()
    {
        isTaken= false;
    }
}
