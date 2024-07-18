using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_ai : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        // tag MainCamera
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rb = GetComponent<Rigidbody>();    
        Launch();
    }

    private void Launch() {
        Debug.Log(player.position + " " + transform.position);
        Vector3 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * speed;
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
