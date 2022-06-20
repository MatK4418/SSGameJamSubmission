using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatrolState", menuName = "FSM/Patrol", order = 2)]

public class PatrolScript : AbstractFSMState
{
    Transform[] patrolPoints;
    int patrolPointIndex;

    //private GameObject enemyObj;
    private detectPlayer dPlayer;

    public override void OnEnable()
    {
        //enemyObj = enemyName;

        base.OnEnable();
        StateType = FSMStateType.PATROL;
        patrolPointIndex = -1;
    }

    public override bool EnterState()
    {
        if (base.EnterState())
        {
            patrolPoints = npc.PatrolPoints;

            if (patrolPoints == null || patrolPoints.Length == 0)
            {
                Debug.LogError("PATROLSTATE: Failed To Grab Patrol Points From The NPC.");
            }

            else
            {
                if (patrolPointIndex < 0)
                    patrolPointIndex = Random.Range(0, patrolPoints.Length);
                else
                    patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;

                SetDestination(patrolPoints[patrolPointIndex]);

                enteredState = true;
            }
        }
        return enteredState;
    }

    public override void UpdateState()
    {
        dPlayer = enemyObj.GetComponent<detectPlayer>();
        if (dPlayer.detected == true) // WHY DOESNT THIS FUCKING SHIT WORK //https://forum.unity.com/threads/solved-gameobject-find-doesnt-work.29861/ check if this works
        {
            fsm.EnterState(FSMStateType.CHASE);
        }

        if (enteredState)
        {
            if (Vector3.Distance(navMeshAgent.transform.position, patrolPoints[patrolPointIndex].position) <= 1f)
            {
                fsm.EnterState(FSMStateType.IDLE);
            }
        }
    }

    private void SetDestination(Transform destination)
    {
        if(navMeshAgent != null && destination != null)
        {
            navMeshAgent.SetDestination(destination.transform.position);
        }
    }
}