using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    protected CharacterController cc;
    protected Vector3 movement;
    float moveSpd, jumpSpd;
    float grav;
    public short health ,health_max;
    protected short rotOffset;
    protected enum direction
    {
        hor, ver
    }

    protected void initiate(float ms, float js, short h, short mh, short ro)//how fast it moves, how high it jumps and how tough it is
    {
        rotOffset = ro;
        grav = 20;
        moveSpd = ms;
        jumpSpd = js;
        health = h;
        health_max = mh;
        cc = GetComponent<CharacterController>();
    }

    protected void addSpd(direction dir, float mod) //Add the direction to follow
    {
        if (dir == direction.hor)
        {
            movement.x = moveSpd * mod;
            if (movement.x < 0) //Moonwalking preventation initiative
                transform.eulerAngles = new Vector3(0, 180 + rotOffset, 0);
            else if (movement.x > 0)
                transform.eulerAngles = new Vector3(0, 0 + rotOffset, 0);
        }
        if (dir == direction.ver)
        {
            movement.y = jumpSpd * mod;
        }
    }

    protected void addSpd(direction dir, float mod, short over) //Add the direction to follow at a diffrent pace
    {
        if (dir == direction.hor)
        {
            movement.x = over * mod;
            if (movement.x < 0)
                transform.eulerAngles = new Vector3(0, 180 + rotOffset, 0);
            else if (movement.x > 0)
                transform.eulerAngles = new Vector3(0, 0 + rotOffset, 0);
        }
        if (dir == direction.ver)
        {
            movement.y = over * mod;
        }
            
    }

    protected void move() //Push yourself in the right direction
    {
        cc.Move(movement * Time.deltaTime);
        if (!cc.isGrounded) // Always know on what ground you are standing
            movement.y -= grav * Time.deltaTime;
        else
            movement.y = -1;
        if (cc.velocity.y == 0 && movement.y > 0) //And try not to hit your head too hard
            movement.y = 0;

    }

    public void addHealth(short add)
    {
        if (health > 0)
        {
            health += add;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("Enemy died");
                Destroy(gameObject);
            }
            else if (health > health_max)
                health = health_max;
        }
    }
}
