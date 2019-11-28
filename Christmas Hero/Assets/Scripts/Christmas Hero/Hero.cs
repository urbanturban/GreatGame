using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    private GameObject present;
    private bool isCarrying;
    private Animator animator;

    void Start()
    {
        isCarrying = false;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }

    public void activateCarrying()
    {
        animator.SetBool("isCarrying", true);
        isCarrying = true;
    }

    public void deactivateCarrying()
    {
        animator.SetBool("isCarrying", false);
        isCarrying = false;
    }

    public bool carrying()
    {
        return isCarrying;
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Present"))
        {
            animator.SetBool("isCarrying", true);
            other.GetComponent<PresentScript>().pickup();
            isCarrying = true;
        }
        else if (other.CompareTag("House")){
            animator.SetBool("isCarrying", false);
            Debug.Log("Entered house area!");
            if (isCarrying) {
                GameObject.Find("presentHolder").GetComponentInChildren<PresentScript>().drop();
                Debug.Log("DROPPED PRESENT");
            }
        }
    }
    */

    }
