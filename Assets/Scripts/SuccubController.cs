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
            if (shouldJump)
            {
                Debug.Log("casting");
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
        Vector3 tmp = chaseDir;
        tmp.y += 1;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, tmp.normalized, out hit, 20f))    //check if there is an obstacle in your way
        {
           // Debug.Log(player.transform.position + "||" + hit.transform.position);
            if (hit.collider.tag == "Player")  //if there is an obstacle - jump
            {
               // Debug.Log("found!");
                shouldJump = true;
            }
        }
    }
}
