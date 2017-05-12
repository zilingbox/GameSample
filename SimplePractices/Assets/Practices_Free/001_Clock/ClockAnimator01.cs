using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator01 : MonoBehaviour {

    //get the trasform to a public value,in the scene,to add the component on it
    public Transform hours;
    public Transform minutes;
    public Transform seconds;

    //get the degree,the const mean the value is not variable,it is a fixed number
    private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
    private const float secondsToDegrees = 360f /60f;

	
	// Update is called once per frame
	private void Update ()
    {
        //DateTime is a struct,it just like a class,but you see it as a simple value,just like integer or Transform
        //Struct-Vlaue-Properties 
        //Class-Object-Method
        //To use the Struct we also need add " using  system" on the top
        //DataTime.Now mean we have a property that can get the current time 
        //So what is a PROPERTY? 
        //a property is a method that pretends to be a variavble.It might be read_only or write_only
        DateTime time = DateTime.Now;

        //localRotation is focuse on the child of clock,if you want clock rotate,they can rotate independently
        //Quaternion is used for rotate
        hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
}
