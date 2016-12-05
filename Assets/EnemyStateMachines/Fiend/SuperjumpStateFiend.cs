using UnityEngine;
using System.Collections;

public class SuperjumpStateFiend : IEnemyState  {

    private readonly StatePatternFiend enemy;

    public SuperjumpStateFiend(StatePatternFiend statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        enemy.setChaseDir();
        jump();
        if (!enemy.isSuperjumping)
        {
            ToChaseState();
        }
        
    }


    public void ToPatrolState()
    {
        
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void toAttackState()
    {

    }

    public void toSuperjumpState()
    {
        Debug.Log("Can't transition to same state");
    }
    
    public void jump()
    {
        
        enemy.GetComponent<FiendSuperjump>().doSuperjump(enemy.player);
        
    }

    

}
