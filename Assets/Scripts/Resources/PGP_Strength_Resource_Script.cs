using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class PGP_Strength_Resource_Script : MonoBehaviour
{
    public float strength;
    public bool hasSliced = false;

    private void OnDestroy()
    {
        transform.gameObject.GetComponent<InteractableFacade>().UngrabAll();
    }
}
