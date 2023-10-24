using UnityEngine;

public class Bucket_In_Area_Quest_Script : MonoBehaviour
{
    public bool isInArea = false;

    public void setBucketInArea(bool status)
    {
        isInArea = status;
    }
}
