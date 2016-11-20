using UnityEngine;
using System.Collections;

public class PlayerController : CharController
{
    public bool left, blocking, countering;
    public int score;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
    public Canvas GUI;
    // Use this for initialization

    void Start()
    {
        countering = false;
        left = false;
        blocking = false;
        initiate(8, 10, 100, 100, 0);
        score = 0;
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetButton("Fire2"))
        {
            blocking = true;
        }
        else
            blocking = false;

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

            addSpd(direction.ver, -1, 2);
        }
        else
            addSpd(direction.hor, Input.GetAxis("Horizontal"));

        if (GUI != null)
        {
            GUI.GetComponent<Score>().score = score;
            GUI.GetComponent<Score>().health = health;
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

        if (Input.GetKeyDown(KeyCode.E)) { gameObject.GetComponent<FireStrike>().cast(); }
    }

    public void addHealth(short add, GameObject other)
    {
        
        if (health > 0 && !blocking)
        {
            health += add;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("Player Died");
                Application.LoadLevel(Application.loadedLevel);
            }
            else if (health > health_max)
                health = health_max;
        }
        else if (blocking)
        {
            other.GetComponent<CharController>().daze();
        }
    }
    public void addScore(int add)
    {
        score += add;
    }


}
