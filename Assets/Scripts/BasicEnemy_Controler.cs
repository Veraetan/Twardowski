using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class BasicEnemy_Controler : MonoBehaviour {

    public float runSpeed = 6f;
    private float jumpSpeed = 6f;
    private float gravity = 10f;
    private float vSpeed = 0f;
    public byte max_health;
    public byte health;
    private bool jump;
    
    CharacterController cc;
    GameObject player;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
        max_health = 100;
        health = max_health;
        jump = false;
        
    }
	/*
	// Update is called once per frame
	void FixedUpdate () {

        float playerX = player.transform.position.x;
        float enemyX = gameObject.transform.position.x;
        bool playerOnTheRight = playerX > enemyX;

        if (Mathf.Abs(playerX - enemyX) > 0.5f)
        {
            if (playerOnTheRight)
            {
                movement.x = runSpeed;
            }
            else
            {
                movement.x = -runSpeed;
            }
        }
        else
        {
            movement.x = 0f;
        }

        var n = transform.position;
        n.y += 1;
        var heading = n - player.transform.position;
        var distance = heading.magnitude;
        var dir = heading / distance;
        dir.y = 0;

        Debug.DrawRay(n, -dir, Color.red, 5, true);

        if (cc.isGrounded)
        {

        }

        cc.Move(movement * Time.deltaTime);

    }*/

    void FixedUpdate () {

        Vector3 chaseDir = player.transform.position - transform.position;
        chaseDir.y = 0;
        float distance = chaseDir.magnitude;

        //Debug.DrawRay(transform.position, chaseDir / chaseDir.magnitude, Color.red, 5, true);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, chaseDir/chaseDir.magnitude, out hit, 1.5f))
        {
            if(!hit.collider.gameObject.transform.IsChildOf(player.transform))
                jump = true;
        }

        if (distance <= 1.5f)
        {
            Debug.Log("Attacking Player");

            //attacking player code

            if(player.GetComponent<PlayerController>().health >= 0)
                player.GetComponent<PlayerController>().health -= 10;

            Debug.Log(player.GetComponent<PlayerController>().health);

            vSpeed -= gravity * Time.deltaTime;

            cc.Move(new Vector3(0f, vSpeed, 0f) * Time.deltaTime);
        }
        else
        {
            if (cc.isGrounded)
            {
                vSpeed = 0;
                if (jump)
                {
                    vSpeed = jumpSpeed;
                    jump = false;
                }
            }

            vSpeed -= gravity * Time.deltaTime;

            chaseDir = chaseDir.normalized * runSpeed;
            chaseDir.y += vSpeed;

            cc.Move(chaseDir * Time.deltaTime);
        }


        
    }
    
}
