using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGrabMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material grabMaterial;
    public List<MeshRenderer> renderers;
    void Start()
    {
        
    }

    public void changeMaterials() {
        Debug.Log("Changing mat material");
        foreach (MeshRenderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            // Change the last material to grabMaterial
            materials[materials.Length - 1] = grabMaterial;
            // Set the updated materials back to the MeshRenderer
            renderer.materials = materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
