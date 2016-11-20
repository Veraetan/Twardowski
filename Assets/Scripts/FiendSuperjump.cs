using UnityEngine;
using System.Collections;

public class FiendSuperjump : Ability {
    
	void Start () {
        Initialize(4, 1, 8);
	}

    public void doSuperjump(GameObject target) {
        StartCoroutine(superjump(target));
        //GetComponent<FiendController>().shouldSuperjump = false;
    }
	
	private IEnumerator superjump (GameObject target) {

        float dist = Vector3.Distance(transform.position, target.transform.position);


        if (isCooldownOver() && dist > range-1 && dist < range+1)
        {
            startCooldown();
            yield return new WaitForSeconds(castTime);
            GetComponent<FiendController>().shouldSuperjump = true;
        }
        
    }
}
