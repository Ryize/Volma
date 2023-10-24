using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia;

public class Saw_Script_VR : MonoBehaviour
{
    public GameObject pgpFrontVR; // Ссылка на префаб pgpFrontVR
    public GameObject pgpBackVR; // Ссылка на префаб pgpBackVR
    public Rigidbody sawRigidbody; // Rigidbody пилы
    private float velocity; // Скорость пилы
    private PGP_Strength_Resource_Script pgpStatus; // Начальная прочность объекта

    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.root.CompareTag("pgp_item"))
            return;

        velocity = sawRigidbody.velocity.magnitude;
        pgpStatus = other.transform.root.gameObject.GetComponent<PGP_Strength_Resource_Script>();
        pgpStatus.strength -= velocity;
        
        if (pgpStatus.hasSliced)
            return;

        if (pgpStatus.strength < 0.1)
        {
            Split(other.transform.root.gameObject);
            pgpStatus.hasSliced = true;
        }
    }

    private void Split(GameObject other)
    {
        // Получаем позицию и поворот объекта, с которым столкнулась пила
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;

        // Уничтожаем объект
        //other.GetComponent<>()
        Destroy(other);

        // Создаем две половинки объекта pgpFrontVR и pgpBackVR
        Instantiate(pgpFrontVR, position, rotation);
        Instantiate(pgpBackVR, position, rotation);
    }
}
