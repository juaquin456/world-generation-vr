using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slicer : MonoBehaviour
{
    public AudioSource audioSource;

    public InputActionReference trigger;
    private bool isTriggered = false;

    public InputActionReference grip;
    private bool isGripped = false;

    public sliceObject slicerObject;

    private bool slicerObjectActive = false;

    private void StartSlicer()
    {
        if (isTriggered && !isGripped)
        {
            audioSource.Play();
            slicerObjectActive = true;
        }
    }

    private void StopSlicer()
    {
        audioSource.Stop();
        slicerObjectActive = false;
    }

    void Start()
    {
        trigger.action.performed += ctx => { isTriggered = true; StartSlicer(); };
        trigger.action.canceled += ctx => { isTriggered = false; StopSlicer(); };
        grip.action.performed += ctx => { isGripped = true; StopSlicer(); };
        grip.action.canceled += ctx => { isGripped = false; StartSlicer(); };
    }

    // Update is called once per frame
    void Update()
    {
        
        if (slicerObjectActive){
            slicerObject.canSlice = true;
            // Hide the renderer of the slicer object
            slicerObject.slicer.GetComponent<Renderer>().enabled = true;
            
        }
        else {
            slicerObject.canSlice = false;
            slicerObject.slicer.GetComponent<Renderer>().enabled = false;
        }
    }
}
