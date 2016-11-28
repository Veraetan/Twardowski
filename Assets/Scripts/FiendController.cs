using UnityEngine;
using System.Collections;
using System;

public class FiendController : BasicEnemy_Controler {

    public bool isSuperjumping = false;
    private float jumpTime;
    

    void Start () {
        initiate(6, 8, 150, 150, 90);
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update () {

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
                /*if(distance < 8 && distance > 6 && !isSuperjumping)
                {
                    agent.enabled = false;
                    StartCoroutine(superJump(2.0f, 0.5f));
                    agent.enabled = true;
                }*/
                    
            }
        }
        else
        {
            wander();
        }

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        /*
        if (!isSuperjumping && cc.isGrounded && distance > 8 && distance < 10)
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
            move();
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
        }*/

    }

    

    public override void attack()
    {
        GetComponent<FiendAttack>().attack(player);
    }
    
    IEnumerator superJump(float height, float duration)
    {
        isSuperjumping = true;
        //agent.enabled = false;
        //agent.updatePosition = false;
        //agent.updateRotation = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position + Vector3.up;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        isSuperjumping = false;
        //agent.updatePosition = true;
        //agent.updateRotation = true;
        //agent.enabled = true;
    }



}
