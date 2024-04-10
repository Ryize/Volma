using System;
using UnityEngine;

public class Roller_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт валика
     */

    // Кол-во грунтовки на валике
    private CounterTracker primerFlowTracker;

    // Компонент Rigidbody ролика (нужен для вычелсения скорости)
    private Rigidbody rollerRigidbody;

    // Константа для минимальной грунтовки
    private const float MinPrimerThreshold = 0.1f;
    
    // Компонет AudioSource для валика
    private AudioSource rollerAudioSource;

    private void Start()
    {
        primerFlowTracker = GetComponent<CounterTracker>();
        rollerRigidbody = GetComponent<Rigidbody>();
        rollerAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        Transform target = other.transform;
        string targetName = target.name.ToLower();

        if (!rollerAudioSource.isPlaying)
        {
            rollerAudioSource.Play();
        }

        if (targetName.Contains("primerpaint"))
        {
            // Увеличивает кол-во грунтовки на валике с использованием Mathf.Clamp01
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker + rollerRigidbody.velocity.magnitude * 0.5f, 0f, 100f);
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

            // Уменьшает кол-во грунтовки на валике с использованием Mathf.Clamp
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker - rollerRigidbody.velocity.magnitude * 0.1f, 0f, 100f);

            // Проверяем, достаточно ли грунтовки, чтобы намазать
            if (primerFlowTracker.tracker > MinPrimerThreshold && primerLineQuest != null)
            {
                primerLineQuest.ApplyPrimer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (rollerAudioSource.isPlaying)
        {
            rollerAudioSource.Stop();
        }
    }
}