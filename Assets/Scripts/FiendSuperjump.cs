using UnityEngine;
using System.Collections;

public class FiendSuperjump : Ability {
    
	void Start () {
        Initialize(4, 1, 7);
	}

    public void doSuperjump(GameObject target) {
        StartCoroutine(jump(target.transform.position, 0.4f));
    }


    /*
    IEnumerator jump(Vector3 dest, float time)
    {
        if (GetComponent<StatePatternFiend>().isSuperjumping) yield break;

        if (isCooldownOver())
        {
            startCooldown();
            GetComponent<StatePatternFiend>().agent.enabled = false;
            GetComponent<StatePatternFiend>().isSuperjumping = true;
            var startPos = transform.position;
            var timer = 0.0f;

            while (timer <= 1.0f)
            {
                var height = Mathf.Sin(Mathf.PI * timer) * 1;
                transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height;

                timer += Time.deltaTime / time;
                yield return null;
            }

            GetComponent<StatePatternFiend>().isSuperjumping = false;
            GetComponent<StatePatternFiend>().agent.enabled = true;
        }

    }*/

    IEnumerator jump(Vector3 dest, float time)
    {
        

        if (isCooldownOver())
        {
            GetComponent<StatePatternFiend>().isSuperjumping = true;
            startCooldown();
            var startPos = transform.position;
            var timer = 0.0f;

            while (timer <= 1.0f)
            {
                var height = Mathf.Sin(Mathf.PI * timer) * 1.4f;
                transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height;

                timer += Time.deltaTime / time;
                yield return null;
            }

            GetComponent<StatePatternFiend>().isSuperjumping = false;
        }
       

        

    }
}
