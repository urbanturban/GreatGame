using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    private GameObject present;
    private bool isCarrying;
    private Animator animator;

    private string currentZone;

    void Start()
    {
        currentZone = "None";
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

    public string getCurrentZone() {
        return currentZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentZone = other.gameObject.tag;
    }

    private void OnTriggerExit(Collider other){
            currentZone = "None";
    }
}
