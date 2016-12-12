using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    Animator anim;
    public Transform shoulder;
    CharacterController cc;
    bool attacked, done, queue;
	// Use this for initialization
	void Start () {
        cc = GetComponentInParent<CharacterController>();
        anim = GetComponent<Animator>();
        done = true;
        queue = false;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", cc.isGrounded);
        if (cc.velocity.x != 0)
        {
            anim.SetFloat("SpeedMod", 2);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("SpeedMod", 1);
            anim.SetFloat("Speed", 0);
        }
        if(attacked && Input.GetButtonDown("Fire1"))
        {
            queue = true;
        }
        if (queue && attacked && done)
        {
            attacked = false;
            anim.Play("Attack2", 1);
            done = false;
            queue = false;
        }
        else if (Input.GetButtonDown("Fire1") && !attacked && done)
        {
            attacked = true;
            anim.Play("Attack1", 1);
            done = false;
        }

    }
    public void OnAnimEnd()
    {
        attacked = false;
    }

    public void NextAtt()
    {
        done = true;
    }
}
