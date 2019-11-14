using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    private GameObject present;
    private bool isCarrying;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isCarrying = false;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Present"))
        {
            animator.SetBool("isCarrying", true);
            other.GetComponent<Pickup>().pickup();
            isCarrying = true;
        }
        else if (other.CompareTag("House")){
            animator.SetBool("isCarrying", false);
            Debug.Log("Entered house area!");
            if (isCarrying) {
                GameObject.Find("presentHolder").GetComponentInChildren<Pickup>().drop();
                Debug.Log("DROPPED PRESENT");
            }
        }
    }

    }
