using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class BasicEnemy_Controler : MonoBehaviour {

    public float runSpeed = 6f;
    private float jumpSpeed = 6f;
    private float gravity = 10f;
    private float vSpeed = 0f;
    public byte max_health;
    public short health;
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
	
    void FixedUpdate () {

        Vector3 chaseDir = player.transform.position - transform.position;
        Vector3 Dir = chaseDir;
        //chaseDir.y = 0;
        float distance = Dir.magnitude;

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

            vSpeed -= gravity * Time.deltaTime;

            cc.Move(new Vector3(0f, vSpeed, 0f) * Time.deltaTime);
        }
        else
        {
            if (cc.isGrounded)  //if monster is on the ground...
            {
                vSpeed = 0;
                if (jump)   //...and should jump...
                {
                    vSpeed = jumpSpeed;     //then jump
                    jump = false;
                }
            }

            vSpeed -= gravity * Time.deltaTime;

            chaseDir = chaseDir.normalized * runSpeed;
            chaseDir.y += vSpeed;

            if (distance <= 10f)
                cc.Move(chaseDir * Time.deltaTime);
            else
                cc.Move(new Vector3(0f, vSpeed, 0f) * Time.deltaTime);
        }

        if ((cc.collisionFlags & CollisionFlags.Above) != 0)    //if you hit ceiling, stop moving upwards
        {
            if (vSpeed >= 0)
            {
                vSpeed = -gravity;
            }
        }

        //face the player
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 180);

    }
    
}
