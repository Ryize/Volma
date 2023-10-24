using UnityEngine;

public class Cuvette_Instrument_Script : MonoBehaviour
{
    public Rigidbody paintRoller;
    public PaintRoller_Script_VR brush;
    private void OnTriggerEnter(Collider other)
    {
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
