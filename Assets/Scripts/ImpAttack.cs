using UnityEngine;
using System.Collections;

public class ImpAttack : Ability {

    public short attackDmg = 10;
    
	void Start () {

        Initialize(1, 0, 0);
    }
	
	public void attack (GameObject player) {

        if (player.GetComponent<PlayerController>().health > 0 && isCooldownOver())     //if the player is not dead and the cooldown is over...
        {
            startCooldown();
            player.GetComponent<PlayerController>().addHealth(attackDmg);  //attack him
        }
    }
}
