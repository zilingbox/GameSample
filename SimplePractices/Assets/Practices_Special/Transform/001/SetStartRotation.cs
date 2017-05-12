using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartRotation: MonoBehaviour {

    //you can use Vector to store the value of the rotation
    public Vector3 start;
    public bool isLocal = true;

    void Start()
    {
        if (isLocal)
        {
            //you can use transform.localEuerAngles to redefine the rotation
            transform.localEulerAngles = start;
        }
        else {
            transform.eulerAngles = start;
        }
    }
}
