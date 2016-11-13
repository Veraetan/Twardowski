using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class BasicEnemy_Controler : CharController {

    private bool jump;
    
    GameObject player;

	// Use this for initialization
	void Start () {
        initiate(6, 6, 100, 100, 90);
        player = GameObject.FindGameObjectWithTag("Player");
        jump = false;
    }
	
    void FixedUpdate () {

        Vector3 chaseDir = player.transform.position - transform.position;
        float distance = chaseDir.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, chaseDir/chaseDir.magnitude, out hit, 1.5f))    //check if there is an obstacle on your way
        {
            if(hit.collider.tag!="Player")  //if there is an obstacle - jump
                jump = true;
        }

        if (distance <= 1.5f)   //if the player is close...
        {

            if (player.GetComponent<PlayerController>().health > 0)     //... and the player is not dead...
                player.GetComponent<PlayerController>().addHealth(-1);  //attack him

            addSpd(direction.hor, 0);
        }
        else
        {
            if (cc.isGrounded)  //if monster is on the ground...
            {
                if (jump)   //...and should jump...
                {
                    addSpd(direction.ver, 1);     //then jump
                    jump = false;
                }
            }

            if (distance <= 10f)
                addSpd(direction.hor, chaseDir.normalized.x);
            else
                addSpd(direction.hor, 0);
        }

        move();

    }
    
}
