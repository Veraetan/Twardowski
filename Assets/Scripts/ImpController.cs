using UnityEngine;
using System.Collections;
using System;

public class ImpController : BasicEnemy_Controler {

    
    
    void Start () {
        initiate(6, 8, 50, 50, 90);
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        
    }
	/*
	void FixedUpdate () {

        setChaseDir();

        lookForObstacles();

        if (distance <= 1.5f)   //if the player is close...
        {  
            attack();
            shouldJump = false;
        }
        else
        {
            approachPlayer();
            if (cc.isGrounded && shouldJump) jump();
        }
        

        move();

    }*/

    void Update()
    {
        setChaseDir();
        lookForPlayer();

        if (playerDetected)
        {
            if (distance <= 1.5)
            {
                attack();
                agent.enabled = false;
                
            }
            else
            {
                agent.enabled = true;
                agent.SetDestination(target);
            }
        }
        else
        {
            wander();
        }

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

    }

    public override void attack()
    {
        GetComponent<ImpAttack>().attack(player);
        //addSpd(direction.hor, 0);
    }

}
