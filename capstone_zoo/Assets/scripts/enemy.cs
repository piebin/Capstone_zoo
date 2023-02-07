using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enermy : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;

        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
