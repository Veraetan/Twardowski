using UnityEngine;
using System.Collections;

public class ChaseStateFiend : IEnemyState

{

    private readonly StatePatternFiend enemy;


    public ChaseStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        enemy.setChaseDir();
        
        look();
        chase();
        attack();
        jump();
    }

    public void ToPatrolState()
    {
        enemy.agent.enabled = true;
        enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void toAttackState()
    {
        enemy.agent.enabled = false;
        enemy.currentState = enemy.attackState;
    }

    public void toSuperjumpState()
    {
        enemy.agent.enabled = false;
        enemy.currentState = enemy.superjumpState;
    }

    public void toOffMeshLinkState()
    {
        //Debug.Log("going to off mesh link state");
        enemy.agent.enabled = false;
        enemy.previousState = this;
        enemy.currentState = enemy.offMeshLinkState;
    }

    private void look()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), chaseDir, Color.red, 1);
        if (Physics.Raycast(enemy.transform.position + new Vector3(0, 1.5f, 0), enemy.chaseDir, out hit))
        {
            float currTime = Time.time;
            if (hit.collider.tag != "Player" && currTime > enemy.timeOfLastEyeContact + 7)
            {
                ToPatrolState();
            }
            else if (hit.collider.tag == "Player" && enemy.distanceToPlayer < enemy.sightRange)
            {
                enemy.timeOfLastEyeContact = currTime;
            }
        }
    }

    private void chase()
    {
        if (enemy.agent.isOnNavMesh)
        {
            enemy.targetForAgent = enemy.player.transform.position;
            enemy.agent.SetDestination(enemy.targetForAgent);

            if (enemy.agent.isOnOffMeshLink)
            {
                toOffMeshLinkState();
            }
        }

    }

    private void attack()
    {
        if (enemy.distanceToPlayer < 1.5f)
        {
            toAttackState();
        }
    }

    private void jump()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), chaseDir, Color.red, 1);
        if (Physics.Raycast(enemy.transform.position + new Vector3(0, 1.5f, 0), enemy.chaseDir, out hit))
        {
            if (enemy.distanceToPlayer < 8 && enemy.distanceToPlayer > 6 && hit.collider.tag == "Player" && !enemy.isSuperjumping
                    && enemy.player.GetComponent<CharacterController>().isGrounded && enemy.GetComponent<FiendSuperjump>().isCooldownOver())
            {
                toSuperjumpState();
            }
        }


        
    }

}