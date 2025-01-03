using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityObject : MonoBehaviour
{
    public Material opacity;
    private Material origin;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        origin = meshRenderer.material;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Range")){
            meshRenderer.material = opacity;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Range")){
            meshRenderer.material = origin;
        }
        
    }
}
