using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToMenu : MonoBehaviour
{
    [SerializeField]
    private string scene;

    void Start()
    {
        //SceneManager.LoadScene(scene);
        SceneLoader_Script.Instance.LoadScene(scene);
    }
}
