using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.SetDestination(new Vector3(2.5f, 2.5f, 0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_agent.velocity.normalized);
        float angle = Vector3.Angle(_agent.velocity.normalized, new Vector3(1,0,1));
        if (_agent.velocity.normalized.x < transform.up.x)
        {
            //angle *= -1;
        }
        angle = (angle ) % 360.0f;
        Debug.Log(angle);

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z );

    }
}
