using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public abstract class BasicEnemy_Controler : CharController {

    protected bool shouldJump = false,
        playerDetected = false,
        isTraversingOffMeshLink = false;
    protected GameObject player;
    protected Vector3 chaseDir;
    protected float distance, timer;
    public Vector3 target;
    protected NavMeshAgent agent;
    protected float wanderTime = 0f;

    void Start()
    {
        initiate(6, 8, 50, 50, 90);
        //agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    /*
    public abstract void attack();

    protected void jump()
    {
        addSpd(direction.ver, 1);
        shouldJump = false;
    }

    protected void approachPlayer()
    {
        if (distance <= 10f)
            addSpd(direction.hor, chaseDir.normalized.x);
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
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy" && distance < 10f)  //if there is an obstacle - jump
                shouldJump = true;
        }
    }
        
    protected void lookForPlayer()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), chaseDir, Color.red, 1);
        if (Physics.Raycast(transform.position+new Vector3(0,1.5f,0), chaseDir, out hit))
        {
            if (hit.collider.tag == "Player" && distance < 15f)
            {
                playerDetected = true;
                target = player.transform.position;
                timer = Time.time;
            }
            else if (timer+10>Time.time)
            {
                playerDetected = false;

            }
        }

    }

    protected void wander()
    {
        if(Time.time >= wanderTime)
        {
            agent.enabled = true;
            float side = Random.Range(-1f, 1f);
            Vector3 wanderTarget = transform.position;
            wanderTarget += new Vector3(4*side, 0, 0);
            wanderTime += 2.5f;
            target = wanderTarget;
            agent.SetDestination(target);
        }
        
    }
    */
}
