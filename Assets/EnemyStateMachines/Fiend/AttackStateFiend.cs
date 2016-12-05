using UnityEngine;
using System.Collections;
using System;

public class AttackStateFiend : IEnemyState
{

    private readonly StatePatternFiend enemy;

    public AttackStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void toAttackState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToPatrolState()
    {

    }

    public void UpdateState()
    {
        attack(enemy.player);
        ToChaseState();
    }

    public void attack(GameObject target)
    {

        enemy.agent.enabled = false;
        enemy.GetComponent<FiendAttack>().attack(target);
        enemy.agent.enabled = true;
    }
}
