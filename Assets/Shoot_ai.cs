using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_ai : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        Launch();
    }

    private void Launch() {
        Vector3 dir = player.position - transform.position;
        rb.velocity = dir.normalized * speed;
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
