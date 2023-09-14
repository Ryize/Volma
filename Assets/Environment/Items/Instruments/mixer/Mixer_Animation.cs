using UnityEngine;

public class Mixer_Animation : MonoBehaviour
{
    private float speed = 0;
    
    void Update()
    {
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y;
        float z = transform.eulerAngles.z + speed;
        transform.eulerAngles = new Vector3(x, y, z);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed * 10;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
