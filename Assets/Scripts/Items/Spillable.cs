using UnityEngine;

public class Spillable : MonoBehaviour
{
    /*
     * Класс-компонент отвечающий расссыпание(выливание).
    */

    private bool _isSpilling;
    private Vector3 lastRotation;

    void Start()
    {
        _isSpilling = false;
        lastRotation = transform.eulerAngles;
    }

    public bool IsSpilling
    {
        get
        {
            if (lastRotation != transform.eulerAngles)
            {
                lastRotation = transform.eulerAngles;

                float cosX = Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
                float cosZ = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

                if (cosX * cosZ <= -0.1f)
                {
                    _isSpilling |= true;
                }
                else
                {
                    _isSpilling |= false;
                }
            }

            return _isSpilling;
        }
    }
}
