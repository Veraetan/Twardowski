﻿using UnityEngine;
using System.Collections;
using System;

public class ImpController : BasicEnemy_Controler {

    
    
    void Start () {
        initiate(6, 8, 50, 50, 90);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
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

    }

    public override void attack()
    {
        GetComponent<ImpAttack>().attack(player);
        //addSpd(direction.hor, 0);
    }

}
