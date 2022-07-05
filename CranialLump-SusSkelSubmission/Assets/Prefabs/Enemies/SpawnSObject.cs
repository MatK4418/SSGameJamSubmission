using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSObject : MonoBehaviour
{
    private FiniteStateMachine FSMcs;
    [SerializeField]
    private List<AbstractFSMState> exportedStates;

    // NOTE: THIS DOESNT WORK RIGHT NOW!!!

    void Awake()
    {
        FSMcs = GetComponent<FiniteStateMachine>();
        if (FSMcs != null)
        {
            IdleState idleGen = IdleState.CreateInstance("IdleState") as IdleState;
            PatrolScript patrolGen = PatrolScript.CreateInstance("PatrolScript") as PatrolScript;
            ChaseScript chaseGen = ChaseScript.CreateInstance("ChaseScript") as ChaseScript;
            /* im going mad, can i create a copy of a class like this?
            ScriptableObject testClass = AbstractFSMState.CreateInstance("AbstractFSMState") as AbstractFSMState;
            testClass idleGen =
            */

            exportedStates.Add(idleGen);
            exportedStates.Add(patrolGen);
            exportedStates.Add(chaseGen);

            FSMcs.validStates = exportedStates;
        }
    }
}
