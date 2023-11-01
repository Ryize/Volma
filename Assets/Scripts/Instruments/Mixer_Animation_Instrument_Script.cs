using UnityEngine;

public class Mixer_Animation_Instrument_Script : MonoBehaviour
{
    /*
     * Нужен для создания анимации миксера (вращение)
    */
    
    // По умолчанию миксер не вращается
    private float speed = 0;
    
    void Update()
    {
        /*
         * Метод для "кручения" миксера
         *
         * Работает путём изменении координаты Z, которая и добавляет анимацию вращения
        */
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y;
        float z = transform.eulerAngles.z + speed;
        transform.eulerAngles = new Vector3(x, y, z);
    }

    public void SetSpeed(float speed)
    {
        /*
         * Метод для установки скорости
         *
         * Args:
         *  speed: float (скорость, которую мы устанавливаем)
        */
        this.speed = speed * 10;
    }

    public float GetSpeed()
    {
        /*
         * Метод для получения скорости
         *
         * Return:
         *  float (скорость миксера)
        */
        return speed;
    }
}
