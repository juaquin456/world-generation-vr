using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Repulsor : MonoBehaviour
{

    public InputActionReference triggerAction;  // Input action property for the trigger button

    bool isTriggerPressed = false;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAction.action.triggered) {
            Repulse();
        }
    }

    void Repulse() {
        // Create a repulsion in the direction of the controller and push objects away with a force of 10 and a visual effect that is visible for 1 second from the controller
        Debug.Log("Repulsing");

        // Get the controller position and forward direction
        Vector3 controllerPosition = transform.position;
        Vector3 controllerForward = transform.forward;

        // Create a sphere collider at the controller position with a radius of 5
        Collider[] colliders = Physics.OverlapSphere(controllerPosition, 5f);

        // Loop through all the colliders
        foreach (Collider collider in colliders) {
            // Check if the collider has a rigidbody
            if (collider.attachedRigidbody != null) {
                // Calculate the direction from the controller to the collider
                Vector3 direction = collider.transform.position - controllerPosition;

                // Calculate the distance from the controller to the collider
                float distance = direction.magnitude;

                // Normalize the direction
                direction.Normalize();

                // Calculate the repulsion force
                float force = 10f / distance;

                // Apply the repulsion force to the collider
                collider.attachedRigidbody.AddForce(direction * force, ForceMode.Impulse);
            }
        }

    }
}
