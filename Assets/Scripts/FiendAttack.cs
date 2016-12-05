using UnityEngine;
using System.Collections;

public class FiendAttack : Ability {
    
	void Start()
    {
        Initialize(2, 1, 0);
    }
	
	public void attack(GameObject target) {

        if (target.GetComponent<PlayerController>().health > 0 && isCooldownOver())     //if the player is not dead and the cooldown is over...
        {

            StartCoroutine(chargedAttack(target));      //...attack him


        }
    }

    IEnumerator chargedAttack(GameObject target)
    {
        //Debug.Log("coroutine");

        startCooldown();
        Color original = GetComponentInChildren<MeshRenderer>().material.color;
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;

        yield return new WaitForSeconds(castTime * 0.5f);

        GetComponentInChildren<MeshRenderer>().material.color = Color.green;

        yield return new WaitForSeconds(castTime * 0.5f);

        GetComponentInChildren<MeshRenderer>().material.color = original;


        if (GetComponent<StatePatternFiend>().distanceToPlayer < 1.5f)
            target.GetComponent<PlayerController>().addHealth(-20, gameObject);

        Debug.Log("player health: " + target.GetComponent<PlayerController>().health);
        //Debug.Log("end coroutine");


    }
}
