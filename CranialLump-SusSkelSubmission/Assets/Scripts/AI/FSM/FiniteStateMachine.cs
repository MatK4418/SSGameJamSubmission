using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiniteStateMachine : MonoBehaviour
{
    private AbstractFSMState currentState;
    private GameObject thisEnemy;

    [SerializeField]
    private GameObject playerObjectEditor;
    
    public List<AbstractFSMState> validStates;
    private Dictionary<FSMStateType, AbstractFSMState> fsmStates;

    public void Awake()
    {
        thisEnemy = gameObject;

        currentState = null;

        fsmStates = new Dictionary<FSMStateType, AbstractFSMState>();

        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        NPC npc = GetComponent<NPC>();

        foreach(AbstractFSMState state in validStates)
        {
            state.SetExecutingFSM(this);
            state.SetExecutingNPC(npc);
            state.SetNavMeshAgent(navMeshAgent);
            state.SetNPC(thisEnemy); // <--- Sets the current gameobject to the FSM
            state.SetPlayerObject(playerObjectEditor); // <-- Sets the player object to FSM
            fsmStates.Add(state.StateType, state);
        }
    }

    public void Start()
    {
        EnterState(FSMStateType.IDLE);
    }

    public void Update()
    {
        if (currentState != null)
            currentState.UpdateState();
    }

    public void EnterState(AbstractFSMState nextState)
    {
        if (nextState == null)
            return;
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = nextState;
        currentState.EnterState();
    }

    public void EnterState(FSMStateType stateType)
    {
        if (fsmStates.ContainsKey(stateType))
        {
            AbstractFSMState nextState = fsmStates[stateType];
            EnterState(nextState);
        }
    }
}