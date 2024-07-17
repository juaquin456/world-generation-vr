using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_box : MonoBehaviour
{
    public inventory_item crystal_inventory_item;
    public inventory_item nut_inventory_item;
    public inventory_item orb_inventory_item;
    public inventory_item mushroom_inventory_item;

    public BoxCollider boxCollider;

    void OnTriggerEnter(Collider other)
    {
        // Verificar el tipo de objeto que está colisionando
        if (other.GetComponent<crystal_object>())
        {
            crystal_inventory_item.add();
            Destroy(other.gameObject); // eliminar el objeto
        }
        else if (other.GetComponent<nut_object>())
        {
            nut_inventory_item.add();
            Destroy(other.gameObject); // eliminar el objeto
        }
        else if (other.GetComponent<orb_object>())
        {
            orb_inventory_item.add();
            Destroy(other.gameObject); // eliminar el objeto
        }
        else if (other.GetComponent<mushroom_object>())
        {
            mushroom_inventory_item.add();
            Destroy(other.gameObject); // eliminar el objeto
        }
    }
}
