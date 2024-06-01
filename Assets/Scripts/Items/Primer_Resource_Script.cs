using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Primer_Resource_Script : MonoBehaviour
{
    [SerializeField] private Spillable spillable;
    [SerializeField] private float primerSpillingSpeed;
    [SerializeField] private float primerAmount;
    [SerializeField] private Transform leakTransform;

    private Cuvette_Instrument_Script cachedCuvette;

    private void FixedUpdate()
    {
        Spill();
    }

    private void Spill() {
        if (!spillable || !spillable.isSpilling)
        {
            return;
        }

        if (primerAmount > 0.01f)
        {
            spillable.useEffect = true;

            primerAmount = Mathf.Max(primerAmount - primerSpillingSpeed * Time.deltaTime, 0f);
            
            cachedCuvette = RaycastToCuvette();

            if (cachedCuvette)
            {
                cachedCuvette.primerVolume += primerSpillingSpeed * Time.deltaTime;
            }
        }
        else
        {
            spillable.useEffect = false;
        }
    }

    private Cuvette_Instrument_Script RaycastToCuvette()
    {
        Vector3 origin = leakTransform.position;
        Vector3 derection = Vector3.down;

        float distance = 10f;

        RaycastHit cuvette;

        if (!Physics.Raycast(origin, derection, out cuvette, distance))
        {
            return null;
        }

        if (!cuvette.transform.name.ToLower().Contains("cuvette"))
        {
            return null;
        }

        if (cachedCuvette && cachedCuvette.transform == cuvette.transform)
            return cachedCuvette;
        
        return cuvette.transform.GetComponent<Cuvette_Instrument_Script>();
    }
}
