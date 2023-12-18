using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;
using Valve.VR.InteractionSystem;

public class ChannelSwitchScript : MonoBehaviour
{
    /*
     * Класс реализующий смену треков на радио
     *
     * В свойствах скрипта будет масиив AudioTracks.
     * Нужно будет выбрать количество элементов в масииве и добавить трек в нужную нам позицию
     */
    //Заголовок(хз в гайде так делали)
    [Header("List of Tracks")] 
    // Список с треками
    [SerializeField] private AudioClip[] audioTracks;
    
    [Header("Regulators")]
    [SerializeField] public Transform trackRegulator;
    [SerializeField] public Transform valumeRegulator;

    //Индекс текущего трека
    private int trackIndex;
    // Текущее значение поворота крутилки
    private float _lastRotation;
    //Предыдущее значение поворота крутилки
    private float _prevRotation;
    //Аудиосоурс который воспроизводит треки
    private AudioSource radioAudioSource;
    
    // Пределы диапазонов для каждого трека
    private List<float> trackRanges;
    
    /*
     * Метод со стартовыми данными
     */
    void Start()
    {
        // Получение компонента AudioSource
        radioAudioSource = GetComponent<AudioSource>();
        
        //Значение трека поставлено на -1 т.к. 0 занят первым треком в списке
        trackIndex = -1;
        
        //Получаем изначальный угол поворота
        _prevRotation = trackRegulator.localRotation.eulerAngles.y;
        
        if (audioTracks != null && audioTracks.Length > 1)
        {
            trackRanges = new List<float>();
            
            for (int range = 0; range < audioTracks.Length - 1; range++)
            {
                trackRanges.Add(Mathf.Round((float) range / (audioTracks.Length - 1) * 360 + 30));
            }
        }
    }
    
    /*
     * Метод обновления трека и их запуск
     */
    private void UpdateTrack(int index)
    {
        // Если индексы равны, то не меняем трек
        if (index == trackIndex || audioTracks[index] == null) return;
        
        trackIndex = index;
        radioAudioSource.clip = audioTracks[index];
        PlayAudio();
    }
    
    /*
     * Метод запуска трека
     */
    private void PlayAudio()
    {
        radioAudioSource.Play();
    }
    
    /*
     * Метод остановки трека
     */
    private void StopAudio() 
    {
        radioAudioSource.Stop();
    }
    
    /*
     * Основной метод который следит за поворотом ручки
     * Сделал всё в нём а не в отдельном методе потому что лень
     */
    void Update()
    {   
        if (trackRanges == null)
        {
            return;
        }
        
        // Получение актуального значения поворота
        _lastRotation = trackRegulator.localRotation.eulerAngles.y;

        // Изменение громкости
        radioAudioSource.volume = valumeRegulator.localRotation.eulerAngles.y / 180;
        
        //Проверяем изменилось ли значение поворота
        if (Mathf.Approximately(_lastRotation, _prevRotation))
        {
            return;
        }
        
        //Запоминаем новые значения поворота
        _prevRotation = _lastRotation;
        
        foreach (float range in trackRanges)
        {
            if (_lastRotation - range is >= 0 and <= 30f)
            {
                UpdateTrack(trackRanges.IndexOf(range) + 1);
                return;
            }
        }
        
        //Остановка Аудио
        if (_lastRotation is >= 0f and <= 5f)
        {
            StopAudio();
        }
        // Во всех других случаях мы ставим помехи(типа реалистично)
        else
        {
            UpdateTrack(0);
        }
    }
}
