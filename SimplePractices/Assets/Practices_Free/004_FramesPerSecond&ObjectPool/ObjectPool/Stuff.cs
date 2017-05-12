using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject {

    MeshRenderer[] meshRenderers;

    public void SetMaterials(Material m)
    {
        for(int i = 0; i< meshRenderers.Length; i++)
        {
            meshRenderers[i].material = m;
        }
    }

    //Rigidbody body;
    public Rigidbody Body { get; private set; }
    void Awake()
    {
        //body = GetComponent<Rigidbody>();
        Body = GetComponent<Rigidbody>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kill Zone"))
        {
            ReturnToPool();
        }
    }

    void OnLevelWasLoaded()
    {
        ReturnToPool();
    }
}
