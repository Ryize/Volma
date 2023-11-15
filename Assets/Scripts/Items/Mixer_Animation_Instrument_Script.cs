using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Mixer_Animation_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт анимации вращения и воспроизведение звука миксера
     */
    private float _speed;
    private AudioSource _mixerMovementSound;
    private SteamVR_Action_Single _buttonTrigger = 
        SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");
    private Interactable _interactable;
    private Transform _auger;
    private float _augerX, _augerY, _augerZ;

    private void Start()
    {
        _auger = transform.GetChild(2);
        _interactable = GetComponent<Interactable>();
        _mixerMovementSound = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        if (_interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = _interactable.attachedToHand.handType;
            
            Debug.Log("[Mixer_Animation_Instrument_Script] Mixer in hand");
            Debug.Log("[Mixer_Animation_Instrument_Script] _buttonTrigger = " + _buttonTrigger.GetAxis(hand));
            _speed = _buttonTrigger.axis * 10;
        
            _augerX = _auger.eulerAngles.x;
            _augerY = _auger.eulerAngles.y;
            _augerZ = _auger.eulerAngles.z + _speed;
            _auger.eulerAngles = new Vector3(_augerX, _augerY, _augerZ);
        }
        else
        {
            _speed = 0f;
        }
        
        if(_speed > 0f && !_mixerMovementSound.isPlaying)
        {
            
            _mixerMovementSound.Play();
        }

        if(_speed <= 0f && _mixerMovementSound.isPlaying)
        {
            
            _mixerMovementSound.Pause();
        }
    }

    public float GetSpeed()
    {
        return _speed;
    }
}
