using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Repulsor : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference trigger;
    private bool isTriggered = false;
    public InputActionReference grip;
    private bool isGripped = false;

    public Transform shootSource;
    public float distance = 10f;
    public LayerMask layerMask;
    private bool rayActive = false;

    public ParticleSystem attractorParticles;

    public Timer timer;
    public float cost = 1.0f;
    private void StartShoot()
    {
        if (isTriggered && isGripped)
        {
            AudioManager.instance.Play("repulsor");
            attractorParticles.Play();
            rayActive = true;
        }
    }
    private void StopShoot()
    {
        AudioManager.instance.Stop("repulsor");
        attractorParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActive = false;
    }
    public void Start()
    {
        // When trigger is pressed , start shooting
        trigger.action.performed += ctx => { isTriggered = true; StartShoot(); };
        // When trigger is released, stop shooting
        trigger.action.canceled += ctx => { isTriggered = false; StopShoot(); };
        // When grip is pressed, start shooting
        grip.action.performed += ctx => { isGripped = true; StartShoot(); };
        // When grip is released, stop shooting
        grip.action.canceled += ctx => { isGripped = false; StopShoot(); };
    }

    private void Update()
    {
        if (rayActive)
        {
            timer.DecreaseTime(cost);
            RayCastCheck();
        }
    }

    void RayCastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);
        if (hasHit)
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                // push object away
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(shootSource.forward * 100f);
            }
        }
    }
}
