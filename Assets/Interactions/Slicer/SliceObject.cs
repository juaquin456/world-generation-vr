using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class sliceObject : MonoBehaviour
{

    public Transform sliceSource;
    public Transform sliceEnd;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

    public Material crossSectionMaterial;
    public float cutForce = 2000f;

    public bool canSlice = false;
    public GameObject slicer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canSlice)
        {
            bool hasHit = Physics.Linecast(sliceSource.position, sliceEnd.position, out RaycastHit hit, sliceableLayer);
            if (hasHit)
            {
                GameObject target = hit.transform.gameObject;
                Slice(target);
            }
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(sliceEnd.position - sliceSource.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(sliceEnd.position, planeNormal);

        if (hull != null)
        {
            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedObject(lowerHull);

            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedObject(upperHull);

            Destroy(target);
        }
    }

    public void SetupSlicedObject(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        slicedObject.layer = LayerMask.NameToLayer("Sliceable");
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1f);
    }
}
