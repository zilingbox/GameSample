﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    Renderer objRenderer;
	// Use this for initialization
	void Start ()
    {
        Debug.LogError("111111111111111111");
        DelegateHandler.buttonClickDelegate += ChangePosition;
        DelegateHandler.buttonClickDelegate += ChangeColor;
        DelegateHandler.buttonClickDelegate += ChangeRotation;
        objRenderer = GetComponent<Renderer>();
	}
	void ChangePosition()
    {
        transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
    }

    void ChangeColor()
    {
        objRenderer.material.color = Color.yellow;
    }

    void ChangeRotation()
    {
        transform.position = new Vector3(50,50,50);
    }

    // Unsubscribing Delegate
    void OnDisable()
    {
        DelegateHandler.buttonClickDelegate -= ChangeColor;
        DelegateHandler.buttonClickDelegate -= ChangePosition;
        DelegateHandler.buttonClickDelegate -= ChangeRotation;
    }


}
