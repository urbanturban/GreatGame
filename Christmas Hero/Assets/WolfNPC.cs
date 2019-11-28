using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfNPC : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
