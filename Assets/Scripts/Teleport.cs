using UnityEngine;
using System.Collections;

public class Teleport : Ability {

	// Use this for initialization
	void Start () {
        Initialize(15f, 0, 0);
	}
	
	// Update is called once per frame
	public void teleport(GameObject[] points)
    {
        GameObject tmp = null;

        for(int i = 0; i<points.Length; i++)
        {
            int min = i;
            for(int j = i; j < points.Length; j++)
            {
                if (points[min].transform.position.magnitude > points[j].transform.position.magnitude)
                {
                    //Debug.Log("Sorting");
                    min = j;
                }
            }
            if(min != i)
            {
                tmp = points[min];
                points[min] = points[i];
                points[i] = tmp;
            }
        }

        //Debug.Log(isCooldownOver());
        if (isCooldownOver())
        {
            startCooldown();
            foreach (GameObject go in points)
            {
                float dis = (go.transform.position - transform.position).magnitude;

                if (dis > 10f )
                {
                    //Debug.Log(dis);
                    transform.position = go.transform.position;
                    break;
                }
            }
        }
    }
}
