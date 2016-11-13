using UnityEngine;
using System.Collections;

public class PlayerController : CharController
{
    bool left;
    public int score;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
    // Use this for initialization

    void Start()
    {
        left = false;
        initiate(8, 10, 100, 100, 0);
        score = 0;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (jumps != 0 && Input.GetButtonDown("Jump"))
        {
            addSpd(direction.ver, 1);
            jumps--;
        }
        else if(cc.velocity.y<0 && Input.GetButton("Jump"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                left = false;
            else if(Input.GetAxis("Horizontal") < 0)
                left = true;

            if (left)
                addSpd(direction.hor, -1);
            else
                addSpd(direction.hor, 1);

            addSpd(direction.ver, -1, 1);
        }
        else
            addSpd(direction.hor, Input.GetAxis("Horizontal"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();

        if (cc.isGrounded)
        {
            jumps = jumps_max;
        }

        if (Input.GetKeyDown(KeyCode.E)) { gameObject.GetComponent<FireStrike>().cast(); }
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
