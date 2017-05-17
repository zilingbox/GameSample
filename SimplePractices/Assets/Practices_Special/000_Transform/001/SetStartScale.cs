using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartScale : MonoBehaviour {
    
    //so you can discover that!
    //you use vector3 to to store the value.
    //use Transform.localPosition, Transform.localScale, Transform.localEulerAngles to change the
    // position, scale, rotation
    public Vector3 start;

    void Start()
    {
        transform.localScale = start;
    }
   
}
