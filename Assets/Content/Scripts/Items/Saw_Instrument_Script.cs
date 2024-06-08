using UnityEngine;

public class Saw_Instrument_Script : MonoBehaviour
{
    /*
     * Скрипт пилы.
     *
     * Позволяет разрезать объекты (ПГП) пополам.
    */
    
    // Скорость пилы
    [SerializeField] private Rigidbody sawRigidbody;

    private PGP_Item_Script cachedPGP;
    
    private void OnTriggerEnter(Collider other)
    {
	    if (IsCutCollider(other)) return;
	    
	    cachedPGP = GetValidPGP(other.transform);
	    if (cachedPGP)
	    {
		    cachedPGP.SetCutLineVisibility(true);
	    }
    }

    private void OnTriggerStay(Collider other)
    {
	    if (IsCutCollider(other))
	    {
		    cachedPGP = GetValidPGP(other.transform.parent);
		    if (cachedPGP)
		    {
			    cachedPGP.MoveCutLine(other.transform.InverseTransformPoint(transform.position).y);
		    }
	    }

	    if (IsPGPItem(other))
	    {
		    cachedPGP = GetValidPGP(other.transform);
		    if (cachedPGP)
		    {
			    float velocity = Mathf.Clamp01(sawRigidbody.velocity.magnitude * 0.5f);
			    cachedPGP.Hit(velocity);
		    }
	    }
    }
    
    private void OnTriggerExit(Collider other)
    {
	    if (IsCutCollider(other)) return;
	    
	    cachedPGP = GetValidPGP(other.transform);
	    if (cachedPGP)
	    {
		    cachedPGP.SetCutLineVisibility(false);
	    }
    }

    private PGP_Item_Script GetValidPGP(Transform target)
    {
	    if (cachedPGP && cachedPGP.transform == target)
	    {
		    return cachedPGP;
	    }

	    return target.GetComponent<PGP_Item_Script>();
    }
    
    private bool IsCutCollider(Collider collider)
    {
	    return collider.name.ToLower().Contains("cut collider");
    }

    private bool IsPGPItem(Collider collider)
    {
	    return collider.name.ToLower().Contains("pgp_item");
    }
}
