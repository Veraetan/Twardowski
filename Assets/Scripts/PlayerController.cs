using UnityEngine;
using System.Collections;

public class PlayerController : CharController
{

    public int score;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
    // Use this for initialization

    void Start()
    {
        initiate(8, 10, 100, 100, 0);
        score = 0;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        addSpd(direction.hor, Input.GetAxis("Horizontal"));

        if (jumps != 0 && Input.GetButtonDown("Jump"))
        {
            addSpd(direction.ver, 1);
            jumps--;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();

        if (cc.isGrounded)
        {
            jumps = jumps_max;
        }
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
