using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    // Start is called before the first frame update


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
        agent.destination = target.transform.position;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 2)
            Debug.Log("catch");
    }
}
