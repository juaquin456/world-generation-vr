using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootLaserBeam : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public InputActionReference triggerAction;  // Input action property for the trigger button

    bool isTriggerPressed = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
    }

    private void Update()
    {
        triggerAction.action.performed += ctx => isTriggerPressed = true;
        triggerAction.action.canceled += ctx => isTriggerPressed = false;
        if (isTriggerPressed)
        {
            Shoot(transform.position, transform.forward, 10f);
            lineRenderer.enabled = true;
        } else {
            lineRenderer.enabled = false;
        }
    }

    private void Shoot(Vector3 targetPos, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = ray.GetPoint(length);

        if (Physics.Raycast(ray, out RaycastHit hit, length)) {
            endPos = hit.point;
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForceAtPosition(direction * 10f, hit.point);
            }
        }

        lineRenderer.SetPosition(0, targetPos);
        lineRenderer.SetPosition(1, endPos);
        
    }
}
