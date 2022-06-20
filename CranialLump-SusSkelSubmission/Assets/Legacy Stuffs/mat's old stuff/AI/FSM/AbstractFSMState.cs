using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType
{
    IDLE,
    PATROL,
    CHASE,
};

public abstract class AbstractFSMState : ScriptableObject
{
    protected NavMeshAgent navMeshAgent;
    protected NPC npc;
    protected FiniteStateMachine fsm;

    protected GameObject enemyObj; // i made this :^)

    public ExecutionState ExecutionState { get; protected set; }
    public FSMStateType StateType { get; protected set; }

    public bool enteredState { get; protected set; }

    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool EnterState()
    {
        bool successNavMesh = true;
        bool successNPC = true;
        ExecutionState = ExecutionState.ACTIVE;

        successNavMesh = (navMeshAgent != null);

        successNPC = (npc != null);
        return successNavMesh & successNPC;
    }

    public abstract void UpdateState();

    public virtual bool ExitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent localNavMeshAgent)
    {
        if (localNavMeshAgent != null)
            navMeshAgent = localNavMeshAgent;
    }

    public virtual void SetExecutingFSM(FiniteStateMachine localFSM)
    {
        if (localFSM != null)
            fsm = localFSM;
    }

    public virtual void SetExecutingNPC(NPC localNPC)
    {
        if (localNPC != null)
            npc = localNPC;
    }

    // Allows a Monobehaviour to set it's Game Object to the FSM
    public virtual void SetNPC(GameObject npcObj)
    {
        if (npcObj != null)
            enemyObj = npcObj;
    }
}
