using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "FSM/Idle", order = 1)]
public class IdleState : AbstractFSMState
{
    [SerializeField]
    float idleDuration = 1f;
    float totalDuration;

    //private GameObject enemyObj;
    private detectPlayer dPlayer;

    public override void OnEnable()
    {
        // enemyObj = GameObject.Find("Enemy Object"); // Deprecated: Finally found a better solution. See below.
        // enemyObj = GameObject.Find(enemyName); // Even more efficient solution below.
        // enemyObj = enemyName; // I don't even need to do this if the variable is in the FSMState lol

        base.OnEnable();
        StateType = FSMStateType.IDLE;
    }

    public override bool EnterState()
    {
        enteredState = base.EnterState();
        if (enteredState)
        {
            //Debug.Log("ENTERED IDLE STATE.");
            totalDuration = 0f;
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
            totalDuration += Time.deltaTime;
            //Debug.Log("UPDATING IDLE STATE." + totalDuration + " Seconds.");

            if(totalDuration >= idleDuration)
            {
                fsm.EnterState(FSMStateType.PATROL);
            }
        }    
    }

    public override bool ExitState()
    {
        base.ExitState();
        //Debug.Log("EXITING IDLE STATE.");
        return true;
    }
}