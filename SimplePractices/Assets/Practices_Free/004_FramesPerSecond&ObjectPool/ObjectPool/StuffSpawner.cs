using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {



    // public float timeBetweenSpawns;
    public FloatRange timeBetweenSpawns,scale,randomVelocity,angularVelocity;
    public Stuff[] stuffPrefabs;
    float timeSinceLastSpawn;
    float currentSpawnDelay;

    public float velocity;

    public Material stuffMaterial;


    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        // if(timeSinceLastSpawn >= timeBetweenSpawns)
        // {
        //    timeSinceLastSpawn -= timeBetweenSpawns;
        //     SpawnStuff();
        // }
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        //Stuff spwan = Instantiate<Stuff>(prefab);
        Stuff spwan = prefab.GetPooledInstance<Stuff>();
        spwan.transform.localPosition = transform.position;
        spwan.transform.localScale = Vector3.one * scale.RandomInRange;
        spwan.transform.localRotation = Random.rotation;

       

        spwan.Body.velocity = transform.up * velocity + Random.onUnitSphere*randomVelocity.RandomInRange;
        spwan.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;

        spwan.GetComponent<MeshRenderer>().material = stuffMaterial;
        spwan.SetMaterials(stuffMaterial);
    }
}

[System.Serializable]
public struct FloatRange
{
    public float min, max;

    public float RandomInRange
    {
        get
        {
            return Random.Range(min, max);
        }
    }
}

