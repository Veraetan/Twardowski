using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public abstract class BasicEnemy_Controler : CharController {

    protected bool shouldJump = false;
    protected GameObject player;
    protected Vector3 chaseDir;
    protected float distance;

    void FixedUpdate()
    {

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

    public abstract void attack();

    protected void jump()
    {
        addSpd(direction.ver, 1);     //then jump
        shouldJump = false;
    }

    protected void approachPlayer()
    {
        if (distance <= 10f)
            addSpd(direction.hor, chaseDir.normalized.x);
        else
            addSpd(direction.hor, 0);
    }

    protected void setChaseDir()
    {
        chaseDir = player.transform.position - transform.position;
        distance = chaseDir.magnitude;
    }

    protected void lookForObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))    //check if there is an obstacle on your way
        {
            if (hit.collider.tag != "Player")  //if there is an obstacle - jump
                shouldJump = true;
        }
    }
        
    
}
