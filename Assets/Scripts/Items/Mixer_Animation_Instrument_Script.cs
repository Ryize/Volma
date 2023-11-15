using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Mixer_Animation_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт анимации вращения и воспроизведение звука миксера.
    */
    
    // Скорость вращения
    private float _speed;
    
    // Звук при вращении миксера
    private AudioSource _mixerMovementSound;
    
    private SteamVR_Action_Single _buttonTrigger = SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");
    private Interactable _interactable;
    
    // Двигаящаяся часть у миксера
    private Transform _auger;
    
    // Плоскость в которой вращается миксер
    private float _augerX, _augerY, _augerZ;
    
    // Кнопка миксера
    private Transform _button;

    private void Start()
    {
        /*
         * Метод для задания начальных значений
        */
        _auger = transform.GetChild(2);
        _button = transform.GetChild(0);
        
        _interactable = GetComponent<Interactable>();
        _mixerMovementSound = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        /*
         * Метод для вращения и вопроизведения звуков миксера.
         */
        

        // Если миксер в руке
        if (_interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = _interactable.attachedToHand.handType;
            _speed = _buttonTrigger.GetAxis(hand);
            
            // Нажатие кнопки
            //_button.position = new Vector3(0, 2.97f,0.1f + _speed / 10);
            
            
            // Вращение миксера
            _augerX = _auger.eulerAngles.x;
            _augerY = _auger.eulerAngles.y;
            _augerZ = _auger.eulerAngles.z + _speed * 10;
            _auger.eulerAngles = new Vector3(_augerX, _augerY, _augerZ);
        }
        
        // Миксер не в руке
        else
        {
            _speed = 0f;
        }
        
        // Идёт вращение миксера
        if(_speed > 0f && !_mixerMovementSound.isPlaying)
        {
            
            _mixerMovementSound.Play();
            _mixerMovementSound.volume = _speed;
        }

        // Миксер не вращается
        if(_speed <= 0f && _mixerMovementSound.isPlaying)
        {
            
            _mixerMovementSound.Pause();
        }
    }

    /*
     * Метод получения скорости
     *
     * Возвращает скорость миксера
     */
    public float GetSpeed()
    {
        return _speed;
    }
}