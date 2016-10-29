using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
    Vector3 movement;
    public bool facing_right;
    public byte health;
    public byte health_max;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
	// Use this for initialization
	void Start () {
        movement = new Vector3(0f, -10f, 0f);
        health_max = 100;
        health = health_max;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = gameObject.GetComponent<CharacterController>();
        facing_right = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement += new Vector3(8f, 0f, 0f);
            if (!facing_right)
            {
                gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
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
                gameObject.transform.Rotate(new Vector3(0f, -180f, 0f));
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
        if (charCtrl.isGrounded)
        {
            movement.y = -10f;
            jumps = jumps_max;
        }

    }
}
