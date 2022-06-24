using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/Chase", order = 3)]

public class ChaseScript : AbstractFSMState
{
    private NavMeshAgent enemyNav;
    private GameObject playerObj;
    private enemyAttack eAttack;

    public override void OnEnable()
    {
        playerObj = GameObject.Find("PlayerObject"); // Lazy find call.
        base.OnEnable();
        StateType = FSMStateType.CHASE;
    }

    public override bool EnterState()
    {
        enemyNav = enemyObj.GetComponent<NavMeshAgent>();

        // Changes stopping distance to suit behaviour.
        eAttack = enemyObj.transform.GetChild(0).gameObject.GetComponent<enemyAttack>();
        if (eAttack != null)
        {
            if (eAttack.meleeMode == true)
                enemyNav.stoppingDistance = 4f;
            else if (eAttack.meleeMode == false)
                enemyNav.stoppingDistance = 8f;
        }
        

        // This makes it so that the FSM can't switch off this state. [NOTE: If intentions change, SWITCH THIS TO TRUE!!!]
        enteredState = false;
        return enteredState;
    }

    public override void UpdateState()
    {
        // Follows the player.
        enemyNav.SetDestination(playerObj.transform.position);

        // Detects when enemy reaches stopping distance.
        if (!enemyNav.pathPending)
        {
            if (enemyNav.remainingDistance <= enemyNav.stoppingDistance)
            {
                if (!enemyNav.hasPath || enemyNav.velocity.sqrMagnitude == 0f)
                {
                    // Enables attack script.
                    enemyObj.transform.GetChild(0).gameObject.SetActive(true);

                    if (eAttack != null)
                    {
                        if (eAttack.meleeMode == false)
                        {
                            // Points Enemy Object at Player
                            enemyObj.transform.LookAt(playerObj.transform);
                            if (eAttack.attackNow)
                                eAttack.StartCoroutine(eAttack.ShootProjectile(2f));
                        }
                    }
                }
            }
        }
    }
}
