using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader_Script: MonoBehaviour
{
    public static SceneLoader_Script Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Загрузка сцены
    public void LoadScene(string scene)
    {
        StartCoroutine(Transition(scene));
    }

    IEnumerator Transition(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        Vector3 spawnPosition = new Vector3();
        Vector3 spawnRotation = new Vector3();

        if (spawnPoint)
        {
            spawnPosition = spawnPoint.transform.position;
            spawnRotation = spawnPoint.transform.eulerAngles;
        }

        GameObject player = GameObject.Find("Player");
        Debug.Log(player.name);
        if (player)
        {
            Debug.Log(player.name);
            player.transform.position = spawnPosition;
            player.transform.eulerAngles = spawnRotation;
        }
    }
}
