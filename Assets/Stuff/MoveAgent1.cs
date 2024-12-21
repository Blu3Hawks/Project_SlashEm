using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent1 : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float speed;
    [SerializeField] private NavMeshAgent agent;

    private Transform targetPosition;


    private void Start()
    {
        agent.SetAreaCost(3, 20);
        agent.SetAreaCost(4, 30);
        agent.SetAreaCost(5, 40);

        agent.SetDestination(destination.position);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, destination.position) < 1f)
        {
            Console.WriteLine("We got there!");
        }
    }
}
