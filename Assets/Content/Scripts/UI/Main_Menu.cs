using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    /*
     * Класс МЕНЮ
     *
     * Реализует главное меню игры. Функционал
     * 
     */
    
    // Главная сцена
    [Header("Main Scene")] [SerializeField] private string mainScene;

    // Музыка меню
    [Header("Menu music")] [SerializeField]
    private AudioClip menuMusic;

    // Компонент AudioSource
    private AudioSource audioSource;

    // Панель с кнопками
    private Transform panel;
    
    // Текст в меню
    private TMP_Text menuText;
    
    /*
     * Стратовый метод
     *
     * Включает музыку и определяет параметры
     */
    private void Start()
    {
        // Включение музыки
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menuMusic;
        audioSource.Play();

        panel = transform.GetChild(0);
        menuText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    /*
     * Метод показа титров
     *
     * Выключает кнопки меню и добавляет титры с кнопкой назад
     */
    public void About()
    {
        menuText.gameObject.SetActive(true);
        
        panel.GetChild(0).gameObject.SetActive(true);
        
        panel.GetChild(1).gameObject.SetActive(false);
        panel.GetChild(2).gameObject.SetActive(false);
    }

    /*
     * Метод возвращения в меню
     *
     * Включает кнопки меню и убирает титры с кнопкой назад
     */
    public void Back()
    {
        menuText.gameObject.SetActive(false);
        
        panel.GetChild(0).gameObject.SetActive(false);
        
        panel.GetChild(1).gameObject.SetActive(true);
        panel.GetChild(2).gameObject.SetActive(true);
    }

    /*
     * Метод загрузки главной сцены
     */
    public void LoadMainScene()
    {
        LoadScene(mainScene);
    }

    /*
     * Метод загрузки сцены
     *
     * Получает на вход название нужной сцены
     * Args:
     *  scene: string (название сцены)
     */
    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
