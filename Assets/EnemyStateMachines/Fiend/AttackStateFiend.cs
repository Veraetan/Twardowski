﻿using UnityEngine;
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
        enemy.agent.enabled = true;
        enemy.currentState = enemy.chaseState;
    }

    public void ToPatrolState()
    {

    }

    public void toOffMeshLinkState()
    {

    }

    public void toDazeState()
    {
        enemy.agent.enabled = false;
        enemy.shouldBeDazed = false;
        enemy.isDazed = true;
        enemy.dazeTime = Time.time;
        enemy.currentState = enemy.dazeState;
    }

    public void UpdateState()
    {
        attack(enemy.player);

        if (enemy.shouldBeDazed)
        {
            toDazeState();
        }

        if (!enemy.isAttacking)
            ToChaseState();
    }

    public void attack(GameObject target)
    {
        
        enemy.GetComponent<FiendAttack>().attack(target);
    }

    
}
