using UnityEngine;
using System.Collections;

public class ImpAttack : Ability {
    
    
	void Start () {

        Initialize(1, 0, 0);
    }
	
	public void attack (GameObject target) {

        if (target.GetComponent<PlayerController>().health > 0 && isCooldownOver())     //if the player is not dead and the cooldown is over...
        {
            startCooldown();
            target.GetComponent<PlayerController>().addHealth(-10, gameObject);  //attack him

            //Debug.Log("player health: " + target.GetComponent<PlayerController>().health);
        }
    }
}
