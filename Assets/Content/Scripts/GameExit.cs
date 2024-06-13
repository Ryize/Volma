using UnityEditor;
using UnityEngine;

public class GameExit: MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
        Debug.Log("Exiting play mode in editor.");
        EditorApplication.isPlaying = false;
        #else
        Debug.Log("Exiting the application.");
        Application.Quit();
        #endif
    }
}
