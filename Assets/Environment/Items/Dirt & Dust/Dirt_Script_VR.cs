using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Script_VR : MonoBehaviour
{
    public Dirt_Script ds;
    public Rigidbody broom;

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("5");
        // Если взаимодействует не метла
        if (!other.transform.name.ToLower().Contains("broom"))
            return;
        //Debug.Log("6");

        float force = broom.velocity.magnitude * 10;
        //Debug.Log("force = " + force);
        //Debug.Log("broom.velocity = " + broom.velocity);

        // foreach (ContactPoint contact in other.contacts)
        // {
        //     force += contact.normalImpulse;
        // }

        ds.dirtCounter -= force;
    }
}
