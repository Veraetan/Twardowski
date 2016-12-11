using UnityEngine;
using System.Collections;

public class OffMeshLinkStateFiend : IEnemyState
{
    private readonly StatePatternFiend enemy;

    public OffMeshLinkStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        traverse();
    }

    public void ToPatrolState()
    {
        enemy.agent.enabled = true;
        enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        enemy.agent.enabled = true;
        enemy.currentState = enemy.chaseState;
    }

    public void toAttackState()
    {

    }

    public void toOffMeshLinkState()
    {

    }

    public void toPreviousState()
    {
        enemy.agent.enabled = true;
        enemy.currentState = enemy.previousState;
    }

    public void traverse()
    {
        if (!enemy.gameObject.GetComponent<AgentLinkMover>().isTraversing)
        {
            //Debug.Log("going to chase state from offmesh");
            toPreviousState();
        }
    }


}
