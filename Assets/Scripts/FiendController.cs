using UnityEngine;
using System.Collections;
using System;

public class FiendController : BasicEnemy_Controler {
    
    void Start () {
        initiate(6, 8, 150, 150, 90);
        //player = GameObject.FindGameObjectWithTag("Player");
        //agent = GetComponent<NavMeshAgent>();
    }

	/*
	void FixedUpdate () {

        setChaseDir();
        lookForPlayer();
        if (dazed)
        {
            undaze();
            agent.enabled = false;
        }
        else if (playerDetected)
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
                if(distance < 8 && distance > 6 && !isSuperjumping && player.GetComponent<CharacterController>().isGrounded)
                {
                    //agent.enabled = false;
                    agent.Stop();
                    StartCoroutine(Hop(target, 0.4f));
                    agent.Resume();
                    //agent.enabled = true;
                }
                    
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

    IEnumerator Hop(Vector3 dest, float time)
    {
        if (isSuperjumping) yield break;

        agent.enabled = false;
        isSuperjumping = true;
        var startPos = transform.position;
        var timer = 0.0f;

        while (timer <= 1.0f)
        {
            var height = Mathf.Sin(Mathf.PI * timer) * 1;
            transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height;

            timer += Time.deltaTime / time;
            yield return null;
        }
        isSuperjumping = false;
        agent.enabled = true;
    }*/
}




