using System.Collections.Generic;
using UnityEngine;

public class ChannelSwitchScript : MonoBehaviour
{
    /*
     * Класс реализующий смену треков на радио
     *
     * В свойствах скрипта будет масиив AudioTracks.
     * Нужно будет выбрать количество элементов в масииве и добавить трек в нужную нам позицию
     */
    
    //Заголовок
    [Header("List of Tracks")] 
    // Список с треками
    [SerializeField] private AudioClip[] audioTracks;
    
    //Заголовок для кнопок
    [Header("Regulators")]
    // Регулятор треков
    [SerializeField] public Transform trackRegulator;
    // Регулятор громкости
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

        int trackListLength = audioTracks.Length;
        
        if (audioTracks != null && trackListLength > 1)
        {
            trackRanges = new List<float>();
            
            for (int range = 1; range < trackListLength; range++)
            {
                trackRanges.Add(Mathf.Round((float) range / (trackListLength) * 360));
                Debug.Log(trackRanges[range-1]);
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
            float ratio = _lastRotation - range;
            if (ratio >= 0 && ratio <= trackRanges[0] / 2)
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
