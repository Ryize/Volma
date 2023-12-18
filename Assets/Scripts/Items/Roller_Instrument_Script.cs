using UnityEngine;

public class Roller_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт валика
     */

    // Кол-во грунтовки на валике
    private CounterTracker primerFlowTracker;

    // Компонент Rigidbody ролика (нужен для вычелсения скорости)
    private Rigidbody rollerRigidbody;

    // Константа для минимальной грунтовки
    private const float MinPrimerThreshold = 0.1f;

    private void Start()
    {
        // Избегаем лишних вызовов GetComponent, сохраняем ссылки
        primerFlowTracker = GetComponent<CounterTracker>();
        rollerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        Transform target = other.transform;
        string targetName = target.name.ToLower();

        if (targetName.Contains("primerpaint"))
        {
            // Увеличивает кол-во грунтовки на валике с использованием Mathf.Clamp01
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker + rollerRigidbody.velocity.magnitude, 0f, 100f);
            return;
        }

        if (targetName.Contains("primer_line"))
        {
            Primer_Line_Quest primerLineQuest = target.GetComponent<Primer_Line_Quest>();

            // Если грунтовка намазана, выходим
            if (primerLineQuest != null && primerLineQuest.isDone)
            {
                return;
            }

            // Уменьшает кол-во грунтовки на валике с использованием Mathf.Clamp
            primerFlowTracker.tracker = Mathf.Clamp(primerFlowTracker.tracker - rollerRigidbody.velocity.magnitude, 0f, 100f);

            // Проверяем, достаточно ли грунтовки, чтобы намазать
            if (primerFlowTracker.tracker > MinPrimerThreshold && primerLineQuest != null)
            {
                primerLineQuest.ApplyPrimer();
            }
        }
    }
}