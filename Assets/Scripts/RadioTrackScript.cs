using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//создание объекта в папке ScriptableObjects
[CreateAssetMenu(fileName ="RadioTrackScript")]
/*
 * Создаём объект для хранения в себе трека
 */
public class RadioTrackScript : ScriptableObject
{
    public AudioClip trackAudioClip;
}
