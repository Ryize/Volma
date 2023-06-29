using UnityEngine;

/// <summary>
/// Класс для приседания игрока.
/// </summary>
public class SitDown : MonoBehaviour
{
    public GameObject cameraGood;

    private void Update()
    {
        SitDownPls();
    }

    /// <summary>
    /// Выполняет приседание, если нажата клавиша Left Control.
    /// </summary>
    private void SitDownPls()
    {
        // Добавляет приседание на клавишу - левый контрол
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (cameraGood.transform.position.y > 1.35)
                cameraGood.transform.Translate(new Vector3(0, -0.3f, 0));
        }
        else
        {
            if (cameraGood.transform.position.y < 1.4)
                cameraGood.transform.Translate(new Vector3(0, 0.5f, 0));
        }
    }
}