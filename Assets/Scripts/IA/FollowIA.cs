using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    public Transform target;
    public float minDistance = 5.0f;
    public Animator animator;

    bool isFollowing = false;
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
        animator.Play("shot");
        Debug.Log("Start Attack");
    }
}
