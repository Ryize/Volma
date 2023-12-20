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

    /*
     * Стартовый метод
     *
     * Определяет компоненты валика
     */
    private void Start()
    {
        primerFlowTracker = GetComponent<CounterTracker>();
        rollerRigidbody = GetComponent<Rigidbody>();
        rollerAudioSource = GetComponent<AudioSource>();
    }

    /*
     * Метод вызывающийся автоматически, при нахождении валика в коллайдере объекта.
     *
     * Отслеживается грунтовка в кюветке и линия для грунтовки
     * 
     * Увеличивает кол-во грунтовки на валике при нахождении в кюветке
     * Уменьшает кол-во грунтовки на валике при нахождении в на линии грунтовки
     *
     * Проигрывает звук
     *
     * Args:
     *  other: Collider (объект, которого мы коснулись)
     */
    private void OnTriggerStay(Collider other)
    {
        Transform target = other.transform;
        string targetName = target.name.ToLower();

        if (targetName.Contains("primerpaint"))
        {
            // Увеличивает кол-во грунтовки на валике с использованием Mathf.Clamp01
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker + rollerRigidbody.velocity.magnitude, 0f, 500f);
            
            if (!rollerAudioSource.isPlaying)
            {
                rollerAudioSource.Play();
            }
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
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker - rollerRigidbody.velocity.magnitude, 0f, 500f);

            // Проверяем, достаточно ли грунтовки, чтобы намазать
            if (primerFlowTracker.tracker > MinPrimerThreshold && primerLineQuest != null)
            {
                primerLineQuest.ApplyPrimer();
            }
            
            if (!rollerAudioSource.isPlaying)
            {
                rollerAudioSource.Play();
            }
        }
    }

    /*
     * Метод вызывающийся автоматически, при выходе валика из коллайдера объекта.
     *
     * Выключает звук
     * 
     * Args:
     *  other: Collider (объект, которого мы коснулись)
     */
    private void OnTriggerExit(Collider other)
    {
        if (rollerAudioSource.isPlaying)
        {
            rollerAudioSource.Stop();
        }
    }
}