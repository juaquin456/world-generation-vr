using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropItem() {
        Debug.Log("Drop Item");
        Instantiate(gameObject, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}