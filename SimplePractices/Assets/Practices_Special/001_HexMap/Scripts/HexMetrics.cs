using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMetrics
{
    //we pick an edge length to be 10,then the distance from the center to any corner is also 10
    public const float outerRadius = 10f;
    //we can also use the triangle to calculate the inner radius
    public const float innerRadius = outerRadius * 0.866025404f;

    //we use this way to sure the orientation
    public static Vector3[] corners =
    {
        new Vector3(0f,0f,outerRadius),
        new Vector3(innerRadius, 0f,0.5f* outerRadius),
        new Vector3(innerRadius,0f,-0.5f * outerRadius),
        new Vector3(0f,0f,-outerRadius),
        new Vector3(-innerRadius,0f,-0.5f* outerRadius),
        new Vector3(-innerRadius,0f,0.5f * outerRadius),
        new Vector3(0f,0f,outerRadius)
    };
	
}
