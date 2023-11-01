using UnityEngine;

public class Mixer_Animation : MonoBehaviour
{
    //переделать в приватную переменную
    public float speed = 10;
    private AudioSource mixerMovementSound;
    
    void Update()
    {
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y;
        float z = transform.eulerAngles.z + speed;
        transform.eulerAngles = new Vector3(x, y, z);
        mixerMovementSound = this.GetComponentInParent<AudioSource>();
        if(speed > 0f && !mixerMovementSound.isPlaying)
        {
            
            mixerMovementSound.Play();
        }

        if(speed <= 0f && mixerMovementSound.isPlaying)
        {
            
            mixerMovementSound.Pause();
        }
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
