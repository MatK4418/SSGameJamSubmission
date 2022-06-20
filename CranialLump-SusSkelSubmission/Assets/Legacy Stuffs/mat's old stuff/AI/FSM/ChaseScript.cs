using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/Chase", order = 3)]

public class ChaseScript : AbstractFSMState
{
    private NavMeshAgent enemyNav;
    private GameObject playerObj;
    //private GameObject enemyObj;

    public override void OnEnable()
    {
        //enemyObj = GameObject.Find("Enemy Object");
        // [Deprecated; Doesn't work across multiple instances.]

        //enemyObj = enemyObject
        // [Not needed because the script it inherits from (AbstractFSMState) is already storing it.]

        playerObj = GameObject.Find("PlayerObject");
        //enemyNav = enemyObj.GetComponent<NavMeshAgent>();

        base.OnEnable();
        StateType = FSMStateType.CHASE;
    }

    public override bool EnterState()
    {
        enemyNav = enemyObj.GetComponent<NavMeshAgent>();
        // NOTE: Had to move this next 8 lines of code from OnEnable to EnterState because then it would activate once, in the editor (Not during play!) and never again. strange bug.

        // In order for patrolling to work, the agent has to stop at precisely the patrol point in order to go into the idle state.
        // This means the stopping distance needs to be low. Instead of fixing that, I opted to simply change the stopping distance
        // in this state, since this is the only state that utilizes different stopping distances and calls the navmeshagent anyways.
        if (enemyObj.tag == ("Light Enemy"))
        {
            enemyNav.stoppingDistance = 8f;
        }
        if (enemyObj.tag == ("Heavy Enemy"))
        {
            enemyNav.stoppingDistance = 4f;
        }

        // This makes it so that the FSM can't switch off this state.
        enteredState = false;
        return enteredState;
    }

    public override void UpdateState()
    {
        enemyNav.SetDestination(playerObj.transform.position);

        // Source: https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
        if (!enemyNav.pathPending)
        {
            if (enemyNav.remainingDistance <= enemyNav.stoppingDistance)
            {
                if (!enemyNav.hasPath || enemyNav.velocity.sqrMagnitude == 0f)
                {
                    enemyObj.transform.GetChild(0).gameObject.SetActive(true); // Enables attack script.

                    enemyAttack eAttack = enemyObj.transform.GetChild(0).gameObject.GetComponent<enemyAttack>();
                    if (eAttack != null)
                    {
                        if (eAttack.meleeMode == false)
                        {
                            enemyObj.transform.LookAt(playerObj.transform); // Points Enemy Object at Player
                            if (eAttack.attackNow)
                                eAttack.StartCoroutine(eAttack.ShootProjectile(2f));
                        }
                    }
                }
            }
        }
    }
}
