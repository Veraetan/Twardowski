using UnityEngine;
using System.Collections;
using System;

public class AttackStateImp : IEnemyState {

    private readonly StatePatternImp enemy;

    public AttackStateImp(StatePatternImp statePatternEnemy)
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
        enemy.originalColor = enemy.GetComponentInChildren<MeshRenderer>().material.color;
        enemy.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
        enemy.currentState = enemy.dazeState;
    }

    public void UpdateState()
    {
        if(!enemy.isAttacking)
            attack(enemy.player);
        
        if(!enemy.isAttacking && !enemy.shouldBeDazed)
            ToChaseState();

        if (enemy.shouldBeDazed)
        {
            toDazeState();
        }
    }
    
    public void attack(GameObject target)
    {
        enemy.GetComponent<ImpAttack>().attack(target);
    }
}
