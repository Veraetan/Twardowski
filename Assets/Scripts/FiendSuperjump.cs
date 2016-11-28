using UnityEngine;
using System.Collections;

public class FiendSuperjump : Ability {
    
	void Start () {
        Initialize(4, 1, 7);
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
            //GetComponent<FiendController>().shouldSuperjump = true;
        }
        
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
}
