using UnityEngine;
using System.Collections;
using System;

public class ImpController : BasicEnemy_Controler {
    public GameObject hpick;
    
    void Start () {
        
        initiate(6, 8, 50, 50, 90);
        player = GameObject.FindGameObjectWithTag("Player");
        //agent = GetComponent<NavMeshAgent>();
        
    }

    public new void addHealth(short add)
    {
        if (health > 0)
        {
            health += add;
            if (health <= 0)
            {
                health = 0;
                //Debug.Log("Enemy died");
                Instantiate(hpick, new Vector3(transform.position.x, transform.position.y + 1, 0), transform.rotation);
                Destroy(gameObject);
            }
            else if (health > health_max)
                health = health_max;
        }
    }
	/*
    void Update()
    {
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
    }*/

}
