using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Vector3 movement;
    
    bool facing_right;
    public int score;
    public short health;
    public byte health_max;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
    // Use this for initialization
    void Start()
    {
        score = 0;
        movement = new Vector3(0f, -10f, 0f);
        health_max = 100;
        health = health_max;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
        facing_right = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0)
        {
            movement.x = Input.GetAxis("Horizontal") * 8f;
            if (Input.GetAxis("Horizontal") == -1 && facing_right)
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
                facing_right = false;
            }
            else if (Input.GetAxis("Horizontal") == 1 && !facing_right)
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
                facing_right = true;
            }
        }
        else
        {
            movement.x = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W) && jumps != 0)
        {
            movement.y = 10f;
            jumps--;

        }
        if (movement.y > -10f)
        {
            movement += new Vector3(0f, -20f * Time.deltaTime, 0f);

        }

        charCtrl.Move(movement * Time.deltaTime);
        //Check that needs to be after movement was done so char doesnt get stuck.
        if (charCtrl.isGrounded)
        {
            movement.y = -10f;
            jumps = jumps_max;
        }

        //Debug.Log(Input.GetAxis("Horizontal"));
        

    }
    public void addHealth(short add)
    {
        if (health > 0)
        {
            health += add;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("Player Died");
                
            }
            else if (health > health_max)
                health = health_max;
        }
    }
    public void addScore(int add)
    {
        score += add;
    }
}
