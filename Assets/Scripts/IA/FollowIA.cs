using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    public Transform target;
    public float minDistance = 5.0f;
    public Animator animator;
    public GameObject bulletPrefab;
    public float timeBetweenShots = 1f;
    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (Vector3.Distance(target.position, transform.position) < minDistance)
        {
            if (!isAttacking) {
                startAttack();
            }
        } else
        {
            transform.position += transform.forward * Time.deltaTime;
            if (isAttacking)
            {
                stopAttack();
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }

    private void stopAttack()
    {
        isAttacking = false;
        animator.Play("idle");
        Debug.Log("Stop Attack");
    }   

    private void startAttack() {
        isAttacking = true;
        StartCoroutine(Shoot());
        animator.Play("shot");
        Debug.Log("Start Attack");
    }

    IEnumerator Shoot() {
        while (isAttacking) {
            yield return new WaitForSeconds(timeBetweenShots);
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
