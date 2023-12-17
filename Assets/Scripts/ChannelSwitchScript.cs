using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelSwitchScript : MonoBehaviour
{
    /*
     * Класс реализующий смену треков на радио
     * Ссылка на гайд если не понятно(https://www.youtube.com/watch?v=EHKrMWGEZPU)
     *
     *
     * Для того что бы создать трек нужно зайти в папку ScriptableObjects(Assets), нажать ПКМ и в верху выбрать пункт Create.
     * После чего выбрать пункт RadioTrackScript.
     * В создавшийся объект нужно засунуть трек, пункт TrackAudioClip, предварительно закинутый в папку Audio,
     * после чего выбрать крутилку радио и данный скрипт.
     * В свойствах скрипта будет масиив AudioTracks.
     * Нужно будет выбрать количество элементов в масииве и добавить трек в нужную нам позицию, после чего в скрипте прописать логику(по аналогии с остальными). 
     */
    //Заголовок(хз в гайде так делали)
    [Header("List of Tracks")] 
    // Список с треками
    [SerializeField] private RadioTrackScript[] audioTracks;

    //Индекс текущего трека
    private int trackIndex;
    // Текущее значение поворота крутилки
    private float _lastRotation;
    //Предыдущее значение поворота крутилки
    private float _prevRotation;
    //Аудиосоурс который воспроизводит треки
    private AudioSource radioAudioSource;
    /*
     * Методы со стартовыми данными
     *
     */
    void Start()
    {
        // Не особо шарю так сделали в гайде
        radioAudioSource = GetComponent<AudioSource>();
        //Значение трека поставлено на -1 т.к. 0 занят первым треком в списке
        trackIndex = -1;
        //Получаем изначальный угол поворота
        _prevRotation=transform.localRotation.eulerAngles.y;
    }
    /*
     * Метод обновления трека и их запуск
     */
    public void UpdateTrack(int index)
    {
            radioAudioSource.clip = audioTracks[index].trackAudioClip;
            PlayAudio();
    }
    /*
     * Метод запуска трека
     */
    public void PlayAudio()
    {
        radioAudioSource.Play();
    }
    /*
     * Метод остановки трека
     */
    public void StopAudio() 
    {
        radioAudioSource.Stop();
    }
    /*
     * Основной метод который следит за поворотом ручки
     * Сделал всё в нём а не в отдельном методе потому что лень
     */
    void Update()
    {   // Получение актуального значения поворота
        _lastRotation = transform.localRotation.eulerAngles.y;
        //Проверяем изменилось ли значение поворота
        if (_lastRotation != _prevRotation)
        {
            //Запоминаем новые значения поворота
            _prevRotation = _lastRotation;
            //1й трек и его диапазон
            if (_lastRotation >= 30f && _lastRotation <= 60f)
            {
                if (trackIndex != 1)
                {
                    trackIndex = 1;
                    UpdateTrack(trackIndex);
                }
            }
            //2й трек и его диапазон
            else if (_lastRotation >= 120f && _lastRotation <= 150f )
            {
                if (trackIndex != 2)
                {
                    trackIndex = 2;
                    UpdateTrack(trackIndex);
                }
            }
            //3й трек и его диапазон
            else if (_lastRotation >= 210f && _lastRotation <= 240f && trackIndex!=3)
            {
                if (trackIndex != 3)
                {
                    trackIndex = 3;
                    UpdateTrack(trackIndex);
                }
            }
            //4й трек и его диапазон
            else if (_lastRotation >= 300f && _lastRotation <= 330f && trackIndex!=4)
            {
                if (trackIndex != 4)
                {
                    trackIndex = 4;
                    UpdateTrack(trackIndex);
                }
            }
            //Остановка Аудио
            else if (_lastRotation >= 0f && _lastRotation <= 5f)
            {
                StopAudio();
            }
            // Во всех других случаях мы ставим помехи(типа реалистично)
            else
            {
                if (trackIndex != 0)
                {
                    trackIndex = 0;
                    UpdateTrack(trackIndex); 
                }
            }

        }
        
    }
}
