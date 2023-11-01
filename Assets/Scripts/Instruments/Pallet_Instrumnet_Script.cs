using UnityEngine;

public class Pallet_Instrumnet_Script : MonoBehaviour
{
    /*
     * Отвечает за нанесения клея на ПГП
    */
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag.ToLower().Contains("task") || other.tag.ToLower().Contains("basket")))
            return;
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
        
        // Если на шпателе есть клей
        if (!meshRenderer.enabled) {
            // Если объект ведро, жижа замешена и на шпателе нет клея
            if (otherName.Contains("basket") && 
            other.transform.parent.GetChild(3).gameObject.activeSelf) {
                meshRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.ToLower().Contains("task"))
            return;
        
        string otherName = other.transform.name.ToLower();
        MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
        Transform eventZone = other.transform.parent;

        // Если объект event
        if (meshRenderer.enabled && 
        (otherName.Contains("horizontalzone") || otherName.Contains("verticalzone"))) {
            Destroy(other.transform.gameObject);
            meshRenderer.enabled = false;
        }

        // Если пгп не активна
        if (!eventZone.GetChild(0).gameObject.activeSelf)
            return;

        if (otherName.Contains("horizontalglue") || otherName.Contains("verticalglue")) {
            Destroy(other.transform.gameObject);
        }
    }
}
