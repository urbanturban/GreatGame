using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    private GameObject present;
    private bool isCarrying;

    // Start is called before the first frame update
    void Start()
    {
        isCarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Present"))
        {
            other.GetComponent<Pickup>().pickup();
            isCarrying = true;
        }
        else if (other.CompareTag("House")){
            Debug.Log("Entered house area!");
            if (isCarrying) {
                GameObject.Find("presentHolder").GetComponentInChildren<Pickup>().drop();
                Debug.Log("DROPPED PRESENT");
            }
        }
    }

    }
