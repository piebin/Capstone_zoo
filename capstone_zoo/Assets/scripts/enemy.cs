using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enermy : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public Animator anim;


    enum State
    {
        Idle_Battle,
        Attack01,
        RunForwardBattle

    }

    State state;


    void Start()
    {
        state = State.Idle_Battle;
        
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;

        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(state==State.Idle_Battle)
        {
            UpdateIdle();
        }
        if (state == State.RunForwardBattle)
        {
            UpdateRun();
        }
        if (state == State.Attack01)
        {
            UpdateAttack();
        }
    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        target = GameObject.FindWithTag("Player").transform;

        if(target!=null)
        {
            state = State.RunForwardBattle;
            anim.SetTrigger("run");
        }
    }

    private void UpdateRun()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance<=2)
        {
            state = State.Attack01;
            anim.SetTrigger("attack");

        }

        agent.speed = 3.5f;
        agent.destination = target.transform.position;
    }

    private void UpdateAttack()
    {
        agent.speed = 0;
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance>2)
        {
            state = State.RunForwardBattle;
            anim.SetTrigger("run");
        }
    }
}
