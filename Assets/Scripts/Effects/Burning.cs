using UnityEngine;
using System.Collections;

public class Burning : MonoBehaviour {
    CharController charCtrl;
    bool burning;
    float timer;
	// Use this for initialization
	void Start () {
        charCtrl = GetComponent<CharController>();
        burning = false;
        timer = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if (burning)
        {
            if(timer+5 < Time.time)
            {
                burning = false;
                CancelInvoke();
            }
            //Debug.Log(Mathf.CeilToInt(-10 * Time.deltaTime));
            
        }
	}

    public void startburning()
    {
        if (!burning)
        {
            timer = Time.time;
            burning = true;
            InvokeRepeating("burn", 0.0f, 1.0f);
        }
    }

    void burn()
    {
        charCtrl.addHealth(-5);
    }
}
