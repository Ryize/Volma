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
    private float _spinThreshold1 = 180f;
    
    // Пороговое значение для определения поворота
    private float _spinThreshold2 = 270f;

    private Vector3 _lastRotation;

    void Start()
    {
        /*
         * Объявление стандратных переменных
        */
        audioSource = GetComponent<AudioSource>();
        _lastRotation = transform.eulerAngles;
    }

    void Update()
    {
        /*
         * Метод для поворота и воспроизведения звука поворота крана
        */
        float spinMagnitude = Quaternion.Angle(Quaternion.Euler(_lastRotation), transform.rotation);

        if (spinMagnitude > _spinThreshold1)
        {
            audioSource.clip = spinSound;
            audioSource.Play();
        }

        _lastRotation = transform.eulerAngles;
    }
}