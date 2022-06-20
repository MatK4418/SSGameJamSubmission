using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
    [SerializeField]
    Transform[] patrolPoints;

    NavMeshAgent navMeshAgent;
    FiniteStateMachine finiteStateMachine;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        finiteStateMachine = GetComponent<FiniteStateMachine>();
    }

    public Transform[] PatrolPoints
    {
        get
        {
            return patrolPoints;
        }
    }
}