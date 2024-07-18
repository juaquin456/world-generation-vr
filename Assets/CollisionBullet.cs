using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bullet")
        {
            Destroy(other.gameObject);
            // call the function to decrease the health of the player
        }
    }
}
