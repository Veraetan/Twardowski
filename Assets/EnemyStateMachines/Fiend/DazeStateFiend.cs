using UnityEngine;
using System.Collections;
using System;

public class DazeStateFiend : IEnemyState
{

    private readonly StatePatternFiend enemy;

    public DazeStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void toAttackState()
    {

    }

    public void ToChaseState()
    {
        enemy.agent.enabled = true;
        enemy.currentState = enemy.chaseState;
    }

    public void ToPatrolState()
    {

    }

    public void toOffMeshLinkState()
    {

    }

    public void UpdateState()
    {
        if (Time.time > enemy.dazeTime + 2f)
        {
            enemy.GetComponentInChildren<MeshRenderer>().material.color = enemy.originalColor;
            ToChaseState();
        }
    }
    

}
