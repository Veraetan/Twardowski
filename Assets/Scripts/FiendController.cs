using UnityEngine;
using System.Collections;
using System;

public class FiendController : BasicEnemy_Controler {

    public bool isSuperjumping = false;
    private float jumpTime;
    

    void Start () {
        initiate(6, 8, 150, 150, 90);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void FixedUpdate () {

        setChaseDir();

        lookForObstacles();

        if(!isSuperjumping && cc.isGrounded && distance > 8 && distance < 10)
        {
            isSuperjumping = true;

            if(chaseDir.x > 0)
                addSpd(direction.hor, 1, 7);
            else
                addSpd(direction.hor, -1, 7);

            addSpd(direction.ver, 1, 7);

            jumpTime = Time.time;
        }

        


        if (distance <= 1.5f)   //if the player is close, attack
        {
            attack();
            isSuperjumping = false;
        }
        else
        {
            
            if (isSuperjumping)
            {
                cc.Move(movement * Time.deltaTime);
                if (!cc.isGrounded)
                    movement.y -= 5 * Time.deltaTime;
                else
                    movement.y = -1;
                if (cc.velocity.y == 0 && movement.y > 0)
                    movement.y = 0;
            }
            else
            {
                //isSuperjumping = false;
                approachPlayer();
                if (cc.isGrounded && shouldJump) jump();
            }
            move();
        }

        if (cc.isGrounded)
        {
            isSuperjumping = false;
        }

    }

    

    public override void attack()
    {
        GetComponent<FiendAttack>().attack(player);
    }
    
}
