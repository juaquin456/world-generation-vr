using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeItemMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material itemMaterial;
    public List<MeshRenderer> renderers;
    void Start()
    {
        
    }

    public void changeMaterials()
    {
        Debug.Log("Changing item material");
        foreach (MeshRenderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            // Change the last material to grabMaterial
            materials[materials.Length - 1] = itemMaterial;
            // Set the updated materials back to the MeshRenderer
            renderer.materials = materials;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
