using UnityEngine;
using System.Collections;
using System;

public class FiendController : BasicEnemy_Controler {

    public bool shouldSuperjump = false;

    void Start () {
        initiate(6, 8, 150, 150, 90);
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
            if (cc.isGrounded && distance > 7 && distance < 9)
            {
                addSpd(direction.ver, 1f);
                addSpd(direction.hor, 10f);
                //shouldSuperjump = false;
            }
            else
            {
                approachPlayer();
                if (cc.isGrounded && shouldJump) jump();
            }
            
        }

        move();
        
        

    }

    public override void attack()
    {
        GetComponent<FiendAttack>().attack(player);
    }
    
}
