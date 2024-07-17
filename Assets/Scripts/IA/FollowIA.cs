using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    public Transform target;
    public float minDistance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < minDistance)
        {
            Attack();
            return;
        }
        transform.LookAt(target);
        // move only on x and z axis
        transform.position += transform.forward * Time.deltaTime; 
    }

    private void Attack() {
        Debug.Log("Attack");
    }
}
