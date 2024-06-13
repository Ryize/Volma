using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneLoader_Script.Instance.LoadScene(scene);
    }
}
