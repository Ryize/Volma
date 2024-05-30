using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Mixer_Animation_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт анимации вращения и воспроизведение звука миксера.
    */
    
    // Скорость вращения
    [SerializeField]
    private float _speed;
    
    // Звук при вращении миксера
    [SerializeField]
    private AudioSource _mixerMovementSound;
    
    [SerializeField]
    private SteamVR_Action_Single _buttonTrigger = SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");
    [SerializeField]
    private Interactable _interactable;
    
    // Двигаящаяся часть у миксера
    [SerializeField]
    private Transform _auger;
    
    // Плоскость в которой вращается миксер
    private float _augerX, _augerY, _augerZ;
    
    // Кнопка миксера
    [SerializeField]
    private Transform _button;

    void Update()
    {
        calculateSpeed();
    }

    private void calculateSpeed()
    {
        // Если миксер в руке
        if (_interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = _interactable.attachedToHand.handType;
            _speed = _buttonTrigger.GetAxis(hand);
            
            animateMixer();
            ChangeSound();
        }
        
        // Миксер не в руке
        else
        {
            _speed = 0f;
        }
    }

    private void animateMixer()
    {
        // Нажатие кнопки
        _button.localPosition = new Vector3(0, 2.97f,0.1f + _speed / 10);
        
        // Вращение миксера
        _augerX = _auger.eulerAngles.x;
        _augerY = _auger.eulerAngles.y;
        _augerZ = _auger.eulerAngles.z + _speed * 10;
        _auger.eulerAngles = new Vector3(_augerX, _augerY, _augerZ);
    }

    private void ChangeSound()
    {
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

    public float speed
    {
        get { return _speed; }
    }
}