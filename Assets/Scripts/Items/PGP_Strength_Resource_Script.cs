using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class PGP_Strength_Resource_Script : MonoBehaviour
{
    /*
     * Класс для логики распила ПГП.
     *
     * Позволяет распилить ПГП
    */
    
    // Сила/Прочность?
    public float strength;
    
    // Статус "распилености"
    public bool hasSliced = false;

    private void OnDestroy()
    {
        transform.gameObject.GetComponent<InteractableFacade>().UngrabAll();
    }
}
