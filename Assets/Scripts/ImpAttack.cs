﻿using UnityEngine;
using System.Collections;

public class ImpAttack : Ability {
    
    
	void Start () {

        Initialize(2, 1, 0);
    }
	
	public void attack (GameObject target) {
        
        if (target.GetComponent<PlayerController>().health > 0 && isCooldownOver())     //if the player is not dead and the cooldown is over...
        {
            
            StartCoroutine(chargedAttack(target));      //...attack him
            
            
        }
    }

    IEnumerator chargedAttack(GameObject target)
    {
        //Debug.Log("coroutine");
        GetComponent<StatePatternImp>().isAttacking = true;

        startCooldown();
        Color original = GetComponentInChildren<MeshRenderer>().material.color;
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;

        yield return new WaitForSeconds(castTime * 0.5f);

        GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        float dazeReadyTime = Time.time;

        yield return new WaitForSeconds(castTime * 0.5f);

        GetComponentInChildren<MeshRenderer>().material.color = original;
        
        if(GetComponent<StatePatternImp>().distanceToPlayer < 1.5f)
        {
            if(target.GetComponent<PlayerController>().blocking
                && target.GetComponent<PlayerController>().blockingStartTime < Time.time
                    && target.GetComponent<PlayerController>().blockingStartTime > dazeReadyTime)
            {
                GetComponent<StatePatternImp>().shouldBeDazed = true;
            }
            else
            {
                target.GetComponent<PlayerController>().addHealth(-10, gameObject);
            }
            
        }
            

        Debug.Log("player health: " + target.GetComponent<PlayerController>().health);
        //Debug.Log("end coroutine");

        GetComponent<StatePatternImp>().isAttacking = false;

    }
}
