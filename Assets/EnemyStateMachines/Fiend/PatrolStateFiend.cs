using UnityEngine;
using System.Collections;

public class PatrolStateFiend : IEnemyState

{
    private readonly StatePatternFiend enemy;

    public PatrolStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        enemy.setChaseDir();
        //Debug.Log("I am in PatrolState");
        look();
        patrol();
    }


    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void toAttackState()
    {

    }

    private void look()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), chaseDir, Color.red, 1);
        if (Physics.Raycast(enemy.transform.position + new Vector3(0, 1.5f, 0), enemy.chaseDir, out hit))
        {
            if (hit.collider.tag == "Player" && enemy.distanceToPlayer < enemy.sightRange)
            {
                enemy.timeOfLastEyeContact = Time.time;
                ToChaseState();
            }
        }
    }

    void patrol()
    {
        if (Time.time >= enemy.wanderTime)
        {
            enemy.agent.enabled = true;
            float side = Random.Range(-1f, 1f);
            Vector3 wanderTarget = enemy.transform.position;
            wanderTarget += new Vector3(4 * side, 0, 0);
            enemy.wanderTime += 2.5f;
            enemy.targetForAgent = wanderTarget;
            enemy.agent.SetDestination(enemy.targetForAgent);
        }
    }
}