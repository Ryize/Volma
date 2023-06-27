using UnityEngine;

public class SitDown : MonoBehaviour
{
    public GameObject cameraGood;

    void Update()
    {
        SitDownPls();
    }
    
    void SitDownPls()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (cameraGood.transform.position.y > 1.35)
                cameraGood.transform.Translate(new Vector3(0, -0.3f, 0));
        }
        else
        {
            if (cameraGood.transform.position.y < 1.4)
                cameraGood.transform.Translate(new Vector3(0, 0.5f, 0));
        }

    }
}