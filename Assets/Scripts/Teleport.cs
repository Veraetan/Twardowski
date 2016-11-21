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
        /*GameObject tmp = null;
        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log(points[i].transform.position.magnitude);
        }
        
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
        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log(points[i].transform.position.magnitude);
        }
        */
        //Debug.Log(isCooldownOver());
        if (isCooldownOver())
        {
            startCooldown();
            int min = 0;
            for (int i = 0; i < points.Length; i++)
            {
                float dis = (points[i].transform.position - transform.position).magnitude;

                if (dis > 10f && dis<(points[min].transform.position - transform.position).magnitude)
                {
                    Debug.Log(dis);
                    min = i;
                }
            }
            transform.position = points[min].transform.position;
        }
    }
}
