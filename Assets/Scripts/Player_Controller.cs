using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
    Vector3 movement;
    Animator anim;
    bool facing_right;
    public byte health;
    public byte health_max;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        movement = new Vector3(0f, -10f, 0f);
        health_max = 100;
        health = health_max;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
        facing_right = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement += new Vector3(8f, 0f, 0f);
            if (!facing_right)
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
                facing_right = true;
            }
            //Debug.Log(movement);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement -= new Vector3(8f, 0f, 0f);
            //Debug.Log(movement);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement += new Vector3(-8f, 0f, 0f);
            if (facing_right)
            {
                transform.Rotate(new Vector3(0f, -180f, 0f));
                facing_right = false;
            }
                
            //Debug.Log(movement);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement -= new Vector3(-8f, 0f, 0f);
            //Debug.Log(movement);
        }
        if (Input.GetKeyDown(KeyCode.W)&&jumps!=0)
        {
            movement.y = 10f;
            jumps--;
            //Debug.Log(movement);
        }
        if (movement.y>-10f)
        {
            movement += new Vector3(0f, -20f*Time.deltaTime, 0f);
            
        }
        
        //Debug.Log(charCtrl.isGrounded);
        charCtrl.Move(movement*Time.deltaTime);
        //Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("SpeedMod", 2);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("SpeedMod", 1);
            anim.SetFloat("Speed", 0);
        }

        if (charCtrl.isGrounded)
        {
            movement.y = -10f;
            jumps = jumps_max;
        }

    }
}
