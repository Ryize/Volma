using UnityEngine;

public class Cuvette_Instrument_Script : MonoBehaviour
{
    /*
     * Добавляет логику обмакивания валика в кюветку
     */
    
    // Для нахождения скорости валика
    public Rigidbody paintRoller;
    
    // Для установки краски на валик
    public Roller_Instrument_Script brush;
    private void OnTriggerEnter(Collider other)
    {
        /*
         * Метод вызывающийся автоматически, при касании кюветки с объектом.
         *
         * Отслеживается именно валик, тк только он может обмакнуться.
         *
         * Args:
         *  other: Collider (объект, которого мы коснулись)
         */
        // Касаться должен именно валик
        if (other != brush.roller)
            return;
        
        // Скорость движения ролика
        float force = paintRoller.velocity.magnitude * 100;

        // Увеличение кол-ва краски на валике
        brush.paintFlowTracker += force;
        brush.paintFlowTracker = Mathf.Clamp(brush.paintFlowTracker, 0, 100);
    }
}
