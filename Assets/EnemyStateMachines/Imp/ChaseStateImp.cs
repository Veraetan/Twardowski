using UnityEngine;
using System.Collections;

public class ChaseStateImp : IEnemyState

{

    private readonly StatePatternImp enemy;


    public ChaseStateImp(StatePatternImp statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        enemy.setChaseDir();
        //Debug.Log("I am in ChaseState");
        look();
        chase();
        attack();
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

    public void toOffMeshLinkState()
    {
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
            else if(hit.collider.tag == "Player" && enemy.distanceToPlayer < enemy.sightRange)
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
        if(enemy.distanceToPlayer < 1.5f)
        {
            toAttackState();
        }
    }
}