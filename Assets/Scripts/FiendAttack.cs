using UnityEngine;
using System.Collections;

public class FiendAttack : Ability {
    
	void Start()
    {
        Initialize(2, 0, 0);
    }
	
	public void attack(GameObject target) {

        if (target.GetComponent<PlayerController>().health > 0 && isCooldownOver())     //if the player is not dead and the cooldown is over...
        {
            startCooldown();
            target.GetComponent<PlayerController>().addHealth(-20, gameObject);  //attack him

            Debug.Log("player health: " + target.GetComponent<PlayerController>().health);
        }
    }
}
