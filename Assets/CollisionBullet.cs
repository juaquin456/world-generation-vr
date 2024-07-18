using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    public Timer timer;
    public float damage = 10f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);

            timer.DecreaseTime(damage);
            // call the function to decrease the health of the player
        }


    }
}
