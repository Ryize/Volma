using System;
using Unity.VisualScripting;
using UnityEngine;

public class Roller_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт валика
     */

    [SerializeField] private Renderer rollerBruchRender;
    [SerializeField] private float maxPrimerCount;

    // Кол-во грунтовки на валике
    [SerializeField] private CounterTracker primerFlowTracker;

    // Компонент Rigidbody ролика (нужен для вычелсения скорости)
    [SerializeField] private Rigidbody rollerRigidbody;
    
    // Компонет AudioSource для валика
    [SerializeField] private AudioSource rollerAudioSource;

    // Константа для минимальной грунтовки
    private const float MinPrimerThreshold = 0.1f;

    private Cuvette_Instrument_Script cachedCuvette = null;
    

    private void Start()
    {
        primerFlowTracker = GetComponent<CounterTracker>();
        rollerRigidbody = GetComponent<Rigidbody>();
        rollerAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        Paint(other.transform);
    }

    private void Paint(Transform target)
    {
        string targetName = target.name.ToLower();

        if (targetName.Contains("primer"))
        {
            PlaySound();
        }

        if (targetName.Contains("primerpaint"))
        {
            UpdateRoller(-rollerRigidbody.velocity.magnitude * 0.5f);
            
            if (!cachedCuvette) cachedCuvette = target.parent.GetComponent<Cuvette_Instrument_Script>();
            cachedCuvette.primerVolume -= rollerRigidbody.velocity.magnitude * 0.005f;
                
            return;
        }

        if (targetName.Contains("primer_line"))
        {
            Primer_Line_Quest primerLineQuest = target.GetComponent<Primer_Line_Quest>();

            // Если грунтовка намазана, выходим
            if (primerLineQuest != null && primerLineQuest.isDone)
            {
                return;
            }

            UpdateRoller(rollerRigidbody.velocity.magnitude * 0.1f);

            // Проверяем, достаточно ли грунтовки, чтобы намазать
            if (primerFlowTracker.tracker > MinPrimerThreshold && primerLineQuest != null)
            {
                primerLineQuest.ApplyPrimer();
            }
        }
    }

    private void PlaySound(bool play = true)
    {
        if (play)
        {
            if (!rollerAudioSource.isPlaying) rollerAudioSource.Play();
        }
        else
        {
            if (rollerAudioSource.isPlaying) rollerAudioSource.Stop();
        }
    }

    private void UpdateRoller(float rollerPaintCount = 0)
    {
        primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker - rollerPaintCount, 0f, maxPrimerCount);
        float rollerColor = (255 - maxPrimerCount + primerFlowTracker.tracker) / 255;
        Color materialColor = new Color(rollerColor, rollerColor, rollerColor, 1);
        rollerBruchRender.material.color = materialColor;
    }

    private void OnTriggerExit(Collider other)
    {
        PlaySound(false);
    }
}