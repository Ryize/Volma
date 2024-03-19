using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    /*
     * ����� ����
     *
     * ��������� ������� ���� ����. ����������
     * 
     */

    // �������� ������� �����
    private const string MainScene = "Main";

    // �������� ������� ����� (�������������)
    private const string MainSceneCensored = "MainCensored";

    // �������
    [SerializeField]
    private bool isCensored = false;

    // �������� ������� ����
    private const string MenuScene = "Menu";

    // ������ ����
    [Header("Menu music")] [SerializeField]
    private AudioClip menuMusic;

    // ��������� AudioSource
    private AudioSource audioSource;

    // ������ � ��������
    private Transform panel;
    
    // ����� � ����
    private TMP_Text menuText;
    
    /*
     * ��������� �����
     *
     * �������� ������ � ���������� ���������
     */
    private void Start()
    {
        // ��������� ������
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menuMusic;
        audioSource.Play();

        panel = transform.GetChild(0);
        menuText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    /*
     * ����� ������ ������
     *
     * ��������� ������ ���� � ��������� ����� � ������� �����
     */
    public void About()
    {
        menuText.gameObject.SetActive(true);
        
        panel.GetChild(0).gameObject.SetActive(true);
        
        panel.GetChild(1).gameObject.SetActive(false);
        panel.GetChild(2).gameObject.SetActive(false);
    }

    /*
     * ����� ����������� � ����
     *
     * �������� ������ ���� � ������� ����� � ������� �����
     */
    public void Back()
    {
        menuText.gameObject.SetActive(false);
        
        panel.GetChild(0).gameObject.SetActive(false);
        
        panel.GetChild(1).gameObject.SetActive(true);
        panel.GetChild(2).gameObject.SetActive(true);
    }

    /*
     * ����� �������� ������� �����
     */
    public void LoadMainScene()
    {
        if (isCensored)
        {
            LoadScene(MainSceneCensored);
        }
        else
        {
            LoadScene(MainScene);
        }
    }

    /*
     * ����� �������� �����
     *
     * �������� �� ���� �������� ������ �����
     * Args:
     *  scene: string (�������� �����)
     */
    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
