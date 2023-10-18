using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class pgp_Strength : MonoBehaviour
{
    public float strength;
    public bool hasSliced = false;

    private void OnDestroy()
    {
        transform.gameObject.GetComponent<InteractableFacade>().UngrabAll();
    }
}
