using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameObject pickupSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickup() {
        Debug.Log("pickup function called");
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = pickupSpot.transform.position;
        this.transform.parent = GameObject.Find("presentHolder").transform;
    }

    public void drop() {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }

}
