using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour {
    
    //you can define a position use Vector3 or Vector2 to store the values
    public Vector3 start;
    public bool isLocal = true;
	// Use this for initialization
	void Start ()
    {
		if(isLocal)
        {
            //when you want to change the position,you can use the unified Vector value to
            //the transform.LocalPosition.
            transform.localPosition = start;

        }
        else
        {
            transform.position = start;
        }
	}
	

}
