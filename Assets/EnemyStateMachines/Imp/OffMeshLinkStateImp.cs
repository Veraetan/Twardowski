using UnityEngine;
using System.Collections;

public class OffMeshLinkStateImp : IEnemyState

{
    private readonly StatePatternImp enemy;

    public OffMeshLinkStateImp(StatePatternImp statePatternEnemy)
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
            toPreviousState();
        }
    }
    

}