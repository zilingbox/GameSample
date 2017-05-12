using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    //this is just the random limit
    public float xRandom;
    public float yRandom;
    public float zRandom;

    void Awake()
    {
        //this is random value
        float rX = Random.Range(-xRandom, xRandom);
        float rY = Random.Range(-yRandom, yRandom);
        float rZ = Random.Range(-zRandom, zRandom);

        //we first get the box's position value,we also can use this method to get the scale and rotation value
        Vector3 pos = transform.position;
        //we let the value divided into 3 ,and change the 3 value independtly
        pos.x += rX;
        pos.y += rY;
        pos.z += rZ;
        //finally we let the value to the origin transform
        transform.position = pos;

    }

}
