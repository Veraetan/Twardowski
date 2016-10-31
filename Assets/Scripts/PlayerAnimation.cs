using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    Animator anim;
    public Transform shoulder;
    public Animation a;
    CharacterController charCtrl;
    bool attacked;
	// Use this for initialization
	void Start () {
        charCtrl = GetComponentInParent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", charCtrl.isGrounded);
        if (charCtrl.velocity.x != 0)
        {
            anim.SetFloat("SpeedMod", 2);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("SpeedMod", 1);
            anim.SetFloat("Speed", 0);
        }
        if (Input.GetButtonDown("Fire1") && attacked)
        {
            attacked = false;
            anim.Play("Attack2", 1);
        }
        else if (Input.GetButtonDown("Fire1") && !attacked)
        {
            attacked = true;
            anim.Play("Attack1", 1);

        }

    }
    public void OnAnimEnd()
    {
        attacked = false;
    }
}
