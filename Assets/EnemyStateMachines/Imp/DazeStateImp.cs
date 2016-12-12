using UnityEngine;
using System.Collections;
using System;

public class DazeStateImp : IEnemyState
{

    private readonly StatePatternImp enemy;

    public DazeStateImp(StatePatternImp statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void toAttackState()
    {

    }

    public void ToChaseState()
    {
        enemy.isDazed = false;
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
        if(Time.time > enemy.dazeTime + 2f)
        {
            enemy.GetComponentInChildren<MeshRenderer>().material.color = enemy.originalColor;
            ToChaseState();
        }
    }
    
    
}
