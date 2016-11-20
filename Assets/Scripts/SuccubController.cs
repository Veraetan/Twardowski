using UnityEngine;
using System.Collections;

public class SuccubController : BasicEnemy_Controler {

    Teleport tele;
    FireBall fb;
    GameObject[] points;
	// Use this for initialization
	void Start () {
        points = GameObject.FindGameObjectsWithTag("TelePoint");
        player = GameObject.FindGameObjectWithTag("Player");
        initiate(6f, 8f, 50, 50, 0);
        tele = GetComponent<Teleport>();
        fb = GetComponent<FireBall>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        setChaseDir();

        if (distance < 5f)
        {
            tele.teleport(points);
        }

        if(distance < 20f)
        {
            lookForObstacles();
            if (!shouldJump)
            {
                fb.cast(player);
            }
        }
        

        move();
    }

    public override void attack()
    {
        
    }

    protected new void lookForObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))    //check if there is an obstacle on your way
        {
            if (hit.collider.tag != "Player")  //if there is an obstacle - jump
                shouldJump = true;
        }
    }
}
