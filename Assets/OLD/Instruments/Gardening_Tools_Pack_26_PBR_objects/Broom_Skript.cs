using System;
using UnityEngine;

public class Broom_Skript : MonoBehaviour
{
    public Camera playerCamera;
    public float Force = 0.01f;
    public float distance = 10f;
    public GameObject broom;

    private float xForce;
    private float yForce;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && broom.GetComponent<TakenPosition>().isTaken)
        {
            Sweep();
        }
    }

    void Sweep()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distance))
        {
            if (hit.distance > 3)
            {
                return;
            }
            if(hit.transform.tag.ToLower().Contains("dirt"))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(audioSource.clip);
                }
                xForce = Math.Abs(Input.GetAxis("Mouse X")) * Force;
                yForce = Math.Abs(Input.GetAxis("Mouse Y")) * Force;

                hit.transform.GetComponent<Dirt_Script>().dirtCounter -= xForce + yForce;
            }
        }
    }
}
