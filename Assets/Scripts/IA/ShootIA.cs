using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIA : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timeBetweenShots = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


IEnumerator Shoot() {
    while (true) {
        yield return new WaitForSeconds(timeBetweenShots);
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
