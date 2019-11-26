﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentScript : MonoBehaviour
{

    public GameObject pickupSpot;
    public Canvas canvas;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Probably find and assign pickupSpot gameobject here
        // so we don't have to drag it in for every present
    }

    void Update()
    {
        
    }

    public Canvas getRiddleCanvas(){
        return canvas;
    }

    public void testPrint() {
        Debug.Log("PRESENT FUNCTION CALLED!");
    }

    public void pickup() {
        Debug.Log("pickup function called");
        rb.useGravity = false;
        this.transform.position = pickupSpot.transform.position;
        this.transform.parent = pickupSpot.transform;
    }

    public void drop() {
        Debug.Log("Drop function called");
        this.transform.parent = null;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.useGravity = true;
    }

}
