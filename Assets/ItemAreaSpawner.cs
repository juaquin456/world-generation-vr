using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float itemXSpread = 10;
    public float itemZSpread = 10;
    public List<GameObject> items = new List<GameObject>();
    void Start()
    {

    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), 50, Random.Range(-itemZSpread, itemZSpread));
        GameObject clone = Instantiate(items[0], randPosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
