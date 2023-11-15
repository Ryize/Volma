using UnityEngine;

public class VRBladeSpin : MonoBehaviour
{
    /*
     * Скрипт для поворота крана и включения звука поворота крана
    */
    
    // Звук поворота крана
    public AudioClip spinSound;
    private AudioSource audioSource;
    
    // Пороговое значение для определения поворота
    private float spinThreshold1 = 180f;
    
    // Пороговое значение для определения поворота
    private float spinThreshold2 = 270f;

    private Vector3 lastRotation;

    void Start()
    {
        /*
         * Объявление стандратных переменных
        */
        audioSource = GetComponent<AudioSource>();
        lastRotation = transform.eulerAngles;
    }

    void Update()
    {
        /*
         * Метод для поворота и воспроизведения звука поворота крана
        */
        float spinMagnitude = Quaternion.Angle(Quaternion.Euler(lastRotation), transform.rotation);

        if (spinMagnitude > spinThreshold1)
        {
            audioSource.clip = spinSound;
            audioSource.Play();
        }

        lastRotation = transform.eulerAngles;
    }
}