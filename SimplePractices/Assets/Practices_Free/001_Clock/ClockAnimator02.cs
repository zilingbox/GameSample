using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator02 : MonoBehaviour
{
    public Transform hours;
    public Transform minutes;
    public Transform seconds;

    private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
    private const float secondsToDegrees = 360f / 60f;

    public bool analog;

    // Update is called once per frame
    private void Update()
    {
        if (analog)
        {
            //to do
            TimeSpan timespan = DateTime.Now.TimeOfDay;

            hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);

        }
        else
        {
            DateTime time = DateTime.Now;

            //localRotation is focuse on the child of clock,if you want clock rotate,they can rotate independently
            //Quaternion is used for rotate
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
        }
    }
}


